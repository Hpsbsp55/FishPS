using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishprice1 : MonoBehaviour
{
    //public string fishtype = "red";
    public bool redcollide = false;
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
            redcollide = true;
        }
    }

    public bool getifhit()
    {
        return redcollide;
    }





}
