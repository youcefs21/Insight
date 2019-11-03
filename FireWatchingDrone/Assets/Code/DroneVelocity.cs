using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneVelocity : MonoBehaviour
{
    int mode;
    int start;

    float droneSpeed =.3f;
    // 0: Search
    // 1: GoTo
    // 2: Stay (spin)



    int counter;
    Vector3 firePlacement;
    // Start is called before the first frame update
    void Start()
    {
        mode = 0;
        start = 0;

    }

    // Update is called once per frame


    void Update()
    {

        // Shearch
        if (mode == 0)
        {

            // Spin Move.
            // this.start = System.Environment.TickCount;
            if (this.start + 10 <= System.Environment.TickCount)
            {
                transform.Rotate(0, -.1f, 0);
                transform.Translate(droneSpeed, 0, 0);
                this.start = System.Environment.TickCount;
            }



            // get fires
            Vector3[] vector3s = TreeFireGenerator.stack.GetObjects();

            // compire each fire
            for (int i = 0; i < vector3s.Length; i++)
            {
                if (vector3s[i].x != 0 && vector3s[i].z != 0)
                {


                    if (Vector3.Distance(this.transform.position, vector3s[i]) <= 30)
                    {
                        firePlacement = vector3s[i];
                        Debug.Log("Camera: (" + this.transform.position.x + ", " + this.transform.position.z + ")");
                        Debug.Log("There: (" + firePlacement.x + "," + firePlacement.z + ")");
                        Debug.Log(Vector3.Distance(this.transform.position, vector3s[i]) + " <= 30");
                        mode++;

                    }
                }

            }

        }
        else if (mode == 1)
        {


            if (start + 10 <= System.Environment.TickCount)
            {
                // firePlacement.z = this.transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, firePlacement, droneSpeed);
                int start = System.Environment.TickCount;
            }
            // transform.Translate(.1f, 0, 0);



        }
        else if (mode == 2) {

            if (start + 10 <= System.Environment.TickCount) {
                int start = System.Environment.TickCount;
                transform.Rotate(0, -.2f, 0);
            }

        }
    }
}
