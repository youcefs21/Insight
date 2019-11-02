using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFireGenerator : MonoBehaviour
{
    public GameObject[,] allTrees;
    public Material[] mater;
    Renderer[,] rend;
    System.Random rnd;
    public GameObject myPrefab;
    int[,] fireprox;
    int x;
    int y;
    // Start is called before the first frame update
    void Start()
    {
        x = 100;
        y = 100;
        double growBy = 0;
        
        allTrees = new GameObject[x, y];
        rend = new Renderer[x, y];
        fireprox = new int[x, y];
        rnd = new System.Random();
        for (int i = 0; i < x; i++)
        {

            /*
            if (i <= x / 2)
            {
                growBy += 0.1;
            }
            else {
                growBy -= 0.1;
            }
            */
            growBy = 2*Mathf.Cos((float) i/10);
            
            
            
            for (int j = 0; j < y; j++)
            {
                //Instantiate(myPrefab, new Vector3(i, 0.5f, j), Quaternion.identity);
                allTrees[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                double yess = rnd.NextDouble();
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
                


                allTrees[i, j].transform.position = new Vector3(i, h, j);
                
                rend[i, j] = allTrees[i, j].GetComponent<Renderer>();
                rend[i, j].sharedMaterial = mater[0];

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

                if (Above(i,j) != null && Above(i, j).GetComponent<Renderer>().sharedMaterial == mater[1]) {
                    count++;
                }
                if (Below(i, j) != null && Below(i, j).GetComponent<Renderer>().sharedMaterial == mater[1])
                {
                    count++;
                }
                if (Left(i,j) != null && Left(i, j).GetComponent<Renderer>().sharedMaterial == mater[1])
                {
                    count++;
                }
                if (Right(i,j) != null && Right(i,j).GetComponent<Renderer>().sharedMaterial == mater[1])
                {
                    count++;
                }
                switch (count) {
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


        }
        CheckProxFire();


    }
}
