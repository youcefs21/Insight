using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneVelocity : MonoBehaviour
{
   
    
    //float x = 1;
    //float z = 1;
    Vector3 target;
    int mode;
    // Start is called before the first frame update
    void Start()
    {
        mode = 0;
        //target.x = 50;
        //target.y = 0;
        //target.z = 50;
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < TreeFireGenerator.x; i++)
        {
            for (int j = 0; j < TreeFireGenerator.y; j++)
            {
                if (TreeFireGenerator.onFirebool[i, j] == true)
                {
                    target = TreeFireGenerator.allTrees[i, j].transform.position;
                    if (Vector3.Distance(transform.position, target) <= 20f)
                    {
                        //Debug.Log("There is a fire at " + target);
                        mode = 1;
                    }
                }
            }

        }

        Vector3 target2 = new Vector3();
        if (mode == 0)
        {
            
            transform.Rotate(0, Time.deltaTime* 10f, 0);
            transform.Translate(0, 0, -5f * Time.deltaTime);
        }
        
        if (mode == 1)
        {
            target2 = target;
            mode = 2;
        }
        
        if (mode == 2)
        {

            //if (Vector3.Distance(transform.position, target.position) > 0.001f)
            //{
            Debug.Log("target2" + target2);
            transform.position = Vector3.MoveTowards(transform.position, target2, Time.deltaTime * 5f);
            
            //}
            //else mode++;
        }

    }
}
