using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class FireGeneration : MonoBehaviour
{

    public Material[] mater;
    Renderer[] rend;
    System.Random rnd;
    int[] FireChance;
    public GameObject[] trees;
    // Start is called before the first frame update
    void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("Tree");
        Debug.Log(trees[60].transform.position);
        FireChance = new int[trees.Length];
        rend = new Renderer[trees.Length];
        for (int i = 0; i < FireChance.Length; i++)
        {
            rend[i] = trees[i].GetComponent<Renderer>();
            rend[i].sharedMaterial = mater[0];
        }
        Debug.Log(trees.Length);

        rnd = new System.Random();

    }
    

   // GameObject Placement(Vector3 vector) {

        //for (int i = 0; i < trees.Length) 
   // }
    /*
    GameObject AboveObject(GameObject[] nodes, int placement) {
        int gridSize = 10;
        if (nodes.Length > placement + gridSize) {
            return nodes[placement + 10];
        }
    }
    GameObject BottemObject(GameObject[] nodes, int placement)
    {

    }
    GameObject LeftObject(GameObject[] nodes, int placement)
    {

    }
    GameObject RightObject(GameObject[] nodes, int placement)
    {

    }
    */
    /*
    private class Node2{
        private int cellNum;
        private GameObject gameObject;

       
        Node2(GameObject gameObject) {
            this.gameObject = gameObject;
            
        }

        public GameObject getGameObject() {
            return this.gameObject;
        }
    }
    */

    void CheckNum()
    {
        for (int i = 0; i < FireChance.Length; i++)
        {
            if (FireChance[i] == 5)
            {
                rend[i].sharedMaterial = mater[1];
            }
        }
    }

  

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < FireChance.Length; i++)
        {
            FireChance[i] = rnd.Next(10000);
        }
        CheckNum();
    }
}
