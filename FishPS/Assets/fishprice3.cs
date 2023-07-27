using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishprice3 : MonoBehaviour
{
    //public string fishtype = "red";
    public bool orangecollide = false;
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
            orangecollide = true;
        }
    }

    public bool getifhit()
    {
        return orangecollide;
    }





}
