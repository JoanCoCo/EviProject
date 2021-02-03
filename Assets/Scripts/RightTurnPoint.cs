using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTurnPoint : MonoBehaviour
{
    public GameObject leftTurnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Turn(float degrees) {
        transform.RotateAround(leftTurnPoint.transform.position, leftTurnPoint.transform.up, degrees);
    }
}
