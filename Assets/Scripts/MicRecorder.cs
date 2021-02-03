using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicRecorder : MonoBehaviour
{
    AudioSource soundSource;
    public string device = "Built-in Microphone";
    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        soundSource.clip = Microphone.Start(device, true, 10, 44100);
        //soundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) {
            soundSource.clip = Microphone.Start(device, true, 10, 44100);
            soundSource.Play();
        } else if(Input.GetKeyUp(KeyCode.M)){
            Microphone.End(device);
            soundSource.Pause();
        }
    }
}
