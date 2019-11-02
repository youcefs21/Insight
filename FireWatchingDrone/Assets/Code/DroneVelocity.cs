using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneVelocity : MonoBehaviour
{

    //float x = 1;
    //float z = 1;
    int counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        counter++;
        if (counter <= 100 && counter > 0)
        {
            x += 0.01f;
            z += 0.01f;
        }
        else if (counter <= 200 && counter > 100)
        {
            x += 0.01f;
            z -= 0.01f;
        }
        else if (counter <= 300 && counter > 200)
        {
            x -= 0.01f;
            z -= 0.01f;

        }
        else if (counter <= 400 && counter > 300)
        {
            x -= 0.01f;
            z += 0.01f;

        }
        else {
            counter = 0;
        
        }
        */
        counter++;
        if (Time.deltaTime > 500 && Time.deltaTime < 680)
        {
            transform.Rotate(0, -Time.deltaTime, 0);
        }
        transform.Translate(Time.deltaTime*5, 0, Time.deltaTime*0);
    }
}
