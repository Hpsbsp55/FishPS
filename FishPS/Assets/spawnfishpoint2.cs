using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnfishpoint2 : MonoBehaviour 
{
    public int wutfish;
    public GameObject spawnpos;
    public GameObject spawn;
    public GameObject spawn2;
    public GameObject spawn3;
    public Vector3 positionspawn;
    public bool canspawn = true;
    public int amountfish = 0;
    public int spawnposnum = 2; 
    public int delay = 7;
    public int fishnum = 5;
    public bool spawnincrease = false;

    void Start()
    {

        wutfish = Random.Range(1, 4);
        positionspawn = new Vector3(spawnpos.transform.position.x, spawnpos.transform.position.y, spawnpos.transform.position.z);
    }



    void Update()
    {
        if (spawnincrease)
        {
            //call the method from the ui script that decreases delay varible and set it = to delay
        }
        if (wutfish == 1 && canspawn && amountfish < fishnum)
        {
            spawnfish1();
            amountfish++;
        }
        else if (wutfish == 2 && canspawn && amountfish < fishnum)
        {
            spawnfish2();
            amountfish++;
        }
        else if (wutfish == 3 && canspawn && amountfish < fishnum)
        {
            spawnfish3();
            amountfish++;
        }
    }


    public void spawnfish1()
    {
        Instantiate(spawn, positionspawn, Quaternion.identity, spawnpos.transform);
        canspawn = false;
        Invoke("changecan", delay + 3.5f);
        Invoke("whatfish", delay + 3.5f);
    }

    public void spawnfish2()
    {
        Instantiate(spawn2, positionspawn, Quaternion.identity, spawnpos.transform);
        canspawn = false;
        Invoke("changecan", delay + 3.5f);
        Invoke("whatfish", delay + 3.5f);
    }

    public void spawnfish3()
    {
        Instantiate(spawn3, positionspawn, Quaternion.identity, spawnpos.transform);
        canspawn = false;
        Invoke("changecan", delay + 3.5f);
        Invoke("whatfish", delay + 3.5f);
    }

    public void changecan()
    {
        canspawn = true;
    }

    public void whatfish()
    {
        wutfish = Random.Range(1, 4);
    }

    // method with colission with specific tag of handle of harpoon to destroy fish and lower counter

    public int Getpositionofspawn()
    {
        return spawnposnum;
    }








}




