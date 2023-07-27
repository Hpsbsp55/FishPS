using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishprice2 : MonoBehaviour
{
    //public string fishtype = "red";
    public bool tealcollide = false;
    void Start()
    {

    }


    void Update()
    {

    }

    //public string Gettype()
    //{
    //return fishtype;
    //}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hook")
        {
            tealcollide = true;
        }
    }

    public bool getifhit()
    {
        return tealcollide;
    }





}