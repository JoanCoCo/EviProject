using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CamDummy : NetworkBehaviour
{
    public float speed;
    [SyncVar (hook="RpcOnChangeCam")] private WebCamTexture cam;

    // Start is called before the first frame update
    void Start()
    {
        if(this.isLocalPlayer) {
            cam = new WebCamTexture();
            SyncCam();  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ClientRpc] void RpcOnChangeCam(WebCamTexture c) {
        cam = c;
        SyncCam();
    }

    void SyncCam() {
        GetComponent<Renderer>().material.mainTexture = cam;
        if(!cam.isPlaying) {
            cam.Play();
        }
    }
}
