using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTurnPoint : MonoBehaviour
{
    public GameObject rightTurnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Turn(float degrees) {
        transform.RotateAround(rightTurnPoint.transform.position, rightTurnPoint.transform.up, degrees);
    }
}
