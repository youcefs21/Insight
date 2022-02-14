using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TreeFireGenerator : MonoBehaviour
{
    public static GameObject[,] allTrees;
    public Material[] mater;
    Renderer[,] rend;
    System.Random rnd;
    public GameObject myPrefab;
    int[,] fireprox;
    int[,] burnprox;
    public static int x;
    public static int y;
    public static bool[,] onFirebool;
    float seaLevel = -3;

    // Start is called before the first frame update
    void Start()
    {
        x = 100;
        y = 100;
        double growBy = 0;
        Debug.Log("xd");
        allTrees = new GameObject[x, y];
        rend = new Renderer[x, y];
        fireprox = new int[x, y];
        burnprox = new int[x, y];

        rnd = new System.Random();
        onFirebool = new bool[x,y];
        for (int i = 0; i < x; i++)
        {


            growBy = 2*Mathf.Cos((float) i/10);
            
            
            
            for (int j = 0; j < y; j++)
            {
                //Instantiate(myPrefab, new Vector3(i, 0.5f, j), Quaternion.identity);
                allTrees[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                double yess = rnd.NextDouble()/3;
                yess -= 0.5 + growBy;
                float h = 0;
                h += (float)yess;
                /*
                if (i <= y / 2)
                {
                    h += (float) 0.1;
                }
                else {
                    h -= (float) 0.1;
                }
                */
                h += Mathf.Cos(j / 180) * 2;



                h += (float)4 * Mathf.Cos((float)j / 30);
                h += (float)2 * Mathf.Cos((float)j / 12);




                allTrees[i, j].transform.position = new Vector3(i, h, j);
                rend[i, j] = allTrees[i, j].GetComponent<Renderer>();

                rend[i, j].sharedMaterial = mater[0];

                if (h >= seaLevel)
                {
                    rend[i, j].sharedMaterial = mater[0];
                }else
                {
                    rend[i, j].sharedMaterial = mater[3];

                }

            }
        }

    }
    private GameObject Above (int x, int y){

        try
        {
            return (allTrees[x, y + 1]);
        }
        catch {
            return null;
        }
    }
    private GameObject Below(int x, int y)
    {
        try
        {
            return (allTrees[x, y - 1]);
        }
        catch {
            return null;
        }
        
    }
    private GameObject Left(int x, int y)
    {
        try
        {
            return (allTrees[x + 1, y]);
        }
        catch {
            return null;
        }
    }
    private GameObject Right(int x, int y)
    {
        try
        {
            return (allTrees[x - 1, y]);
        }
        catch {
            return null; 
        }
    }

  
    void CheckProxFire()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (fireprox[i, j] == 5)
                {
                    rend[i, j].sharedMaterial = mater[1];
                    onFirebool[i, j] = true;
                }
            }

        }
    }

    void CheckProxBurn()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (burnprox[i, j] == 5)
                {
                    rend[i, j].sharedMaterial = mater[2];
                }
            }
        }
    }

            // Update is called once per frame
            void Update()
    {
       
        int count = 0;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (allTrees[i, j].GetComponent<Renderer>().sharedMaterial == mater[0])
                {



                    if (Above(i, j) != null && Above(i, j).GetComponent<Renderer>().sharedMaterial == mater[1])
                    {
                        count++;
                    }
                    if (Below(i, j) != null && Below(i, j).GetComponent<Renderer>().sharedMaterial == mater[1])
                    {
                        count++;
                    }
                    if (Left(i, j) != null && Left(i, j).GetComponent<Renderer>().sharedMaterial == mater[1])
                    {
                        count++;
                    }
                    if (Right(i, j) != null && Right(i, j).GetComponent<Renderer>().sharedMaterial == mater[1])
                    {
                        count++;
                    }
                    switch (count)
                    {
                        case 0:
                            fireprox[i, j] = rnd.Next(1000000);
                            break;
                        case 1:
                            fireprox[i, j] = rnd.Next(100);
                            break;
                        case 2:
                            fireprox[i, j] = rnd.Next(50);
                            break;
                        case 3:
                            fireprox[i, j] = rnd.Next(25);
                            break;
                        case 4:
                            fireprox[i, j] = rnd.Next(10);

                            break;


                    }
                    count = 0;
                }
                else if (allTrees[i, j].GetComponent<Renderer>().sharedMaterial == mater[1])
                {
                    // Fire's Might burn out
                    if (Above(i, j) != null && Above(i, j).GetComponent<Renderer>().sharedMaterial == mater[1])
                    {
                        count++;
                    }
                    if (Below(i, j) != null && Below(i, j).GetComponent<Renderer>().sharedMaterial == mater[1])
                    {
                        count++;
                    }
                    if (Left(i, j) != null && Left(i, j).GetComponent<Renderer>().sharedMaterial == mater[1])
                    {
                        count++;
                    }
                    if (Right(i, j) != null && Right(i, j).GetComponent<Renderer>().sharedMaterial == mater[1])
                    {
                        count++;
                    }
                    if (Right(i, j) != null && Right(i, j).GetComponent<Renderer>().sharedMaterial == mater[2])
                    {
                        count++;
                    }
                    if (Right(i, j) != null && Right(i, j).GetComponent<Renderer>().sharedMaterial == mater[2])
                    {
                        count++;
                    }
                    if (Right(i, j) != null && Right(i, j).GetComponent<Renderer>().sharedMaterial == mater[2])
                    {
                        count++;
                    }
                    if (Right(i, j) != null && Right(i, j).GetComponent<Renderer>().sharedMaterial == mater[2])
                    {
                        count++;
                    }
                    switch (count)
                    {
                        case 0:
                            burnprox[i, j] = rnd.Next(10000);
                            break;
                        case 1:
                            burnprox[i, j] = rnd.Next(1000);
                            break;
                        case 2:
                            burnprox[i, j] = rnd.Next(1000);
                            break;
                        case 3:
                            burnprox[i, j] = rnd.Next(500);
                            break;
                        case 4:
                            burnprox[i, j] = rnd.Next(250);

                            break;
                    }

                    count = 0;
                }


            }

        }
        CheckProxFire();
        CheckProxBurn();


    }
}
/*
public class Stack{

    private Object[] objects;
    Stack() {

    }
    private void Grow() {
        Object[] extraSpace = Object[this.objects.Length * 2];



    }

}
*/
