using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneVelocity : MonoBehaviour
{

    float x = 1;
    float z = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (x<5)
        {
            x += 0.001f;
            z += 0.001f;
        }
        transform.Translate(Time.deltaTime * x, 0, Time.deltaTime*z);
    }
}
