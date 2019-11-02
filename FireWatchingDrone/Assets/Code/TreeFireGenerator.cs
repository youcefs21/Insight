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
        x = 40;
        y = 100;
        allTrees = new GameObject[x, y];
        rend = new Renderer[x, y];
        fireprox = new int[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Instantiate(myPrefab, new Vector3(i, 0.5f, j), Quaternion.identity);
                allTrees[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                allTrees[i, j].transform.position = new Vector3(i, 0, j);
                
                rend[i, j] = allTrees[i, j].GetComponent<Renderer>();
                rend[i, j].sharedMaterial = mater[0];

            }
        }

        rnd = new System.Random();


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
