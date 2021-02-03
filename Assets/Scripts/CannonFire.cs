using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    public GameObject bullet;
    private float elapsedTime = 0;
    public float fireFrequency = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= fireFrequency) {
            elapsedTime = 0.0f;
            Fire();
        }
    }

    void Fire() {
        GameObject o = Instantiate(bullet, this.transform);
        o.GetComponent<Rigidbody>().AddForce(new Vector3(10.0f, 0.0f, 0.0f), ForceMode.Impulse);
    }
}
