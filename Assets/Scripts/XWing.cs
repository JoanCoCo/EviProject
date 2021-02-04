using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class XWing : NetworkBehaviour
{
    private Rigidbody body;
    public float speed = 1.0f; 
    public float torque = 1.0f;

    public GameObject[] shootingPoints;
    public GameObject bullet;

    public Camera cam;
    private AudioListener listener;

    public LeftTurnPoint leftTurnPoint;
    public RightTurnPoint rightTurnPoint;

    private int accelerate = 0;
    private float previousY;

    public float levitateTolerance = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        listener = cam.GetComponent<AudioListener>();
        if(GameObject.FindWithTag("InitialCamera") != null) {
            GameObject mainCam = GameObject.FindWithTag("InitialCamera");
            mainCam.GetComponent<Camera>().enabled = false;
            mainCam.GetComponent<AudioListener>().enabled = false;
        }
        previousY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isLocalPlayer)
        {
            if (!cam.enabled) { cam.enabled = true; listener.enabled = true; }
            body.AddTorque(transform.right * Input.GetAxis("Vertical") * torque, ForceMode.Impulse);
            body.AddTorque(transform.up * Input.GetAxis("Horizontal") * torque, ForceMode.Impulse);
            body.AddForce(transform.forward * accelerate * speed, ForceMode.Impulse);

            //print(transform.position.y);
            //print("P: " + previousY);
            if((previousY - transform.position.y) >= levitateTolerance) {
                body.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * body.mass * 9.8f * (previousY - transform.position.y));
            }

            if(Input.GetKeyDown(KeyCode.Space)) {
                foreach (var o in shootingPoints)
                {
                    GameObject b = Instantiate(bullet, o.transform.position, o.transform.rotation);
                    //Destroy(b);
                    Shoot(b);
                }
            }

            if(Input.GetKeyDown(KeyCode.Q)) {
                accelerate = 1;
            } else if(Input.GetKeyDown(KeyCode.E)) {
                accelerate = -1;
            }

            if(Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E)) {
                accelerate = 0;
            }
        }
        else
        {
            if(cam.enabled) {
                cam.enabled = false;
                listener.enabled = false;
            }
        }
    }

    [Command] 
    public void Shoot(GameObject o) {
        if(this.isServer) NetworkServer.Spawn(o);
    }
}
