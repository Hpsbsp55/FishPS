using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishmovement : MonoBehaviour
{
    [SerializeField] public spawnfishpoint spawnposition;
    public int wutposition;
    //public float fishspeed;
    public GameObject thisfish;
    public bool ismove = true;
    public Rigidbody rb;
    public GameObject spawnpos;
    public GameObject spawnpos2;
    public GameObject spawnpos3;
    public GameObject parentspawn;
    public int x = 0;
    public bool isspawn;
    public bool isspawn1;
    public bool isspawn2;
    public bool hooked = false;
    public bool eaten = false;
    public bool sold = false;


    void Start()
    {
        



    }
    
    
    void Update()
    {
        
        if (isspawn && ismove && !hooked)
        {
            move1();
        }
        else if(isspawn1 && ismove && !hooked)
        {
            move2();
        }
        else if(isspawn2 && ismove && !hooked)
        {
            move3();
        }
        if(hooked)
        {
            // eaten and sold bool is taken from ui script
            // if eat, destroy and change spawnincrease in spawner scripts 
            // if sold, destroy, change ui text for debt in ui
        }
        
    }

    public void move1()
    {
        rb.velocity = new Vector3(0, 0, 10);
        ismove = false;
        Invoke("move11", 1.5f);
    }

    public void move11()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(-10, 0, 0);
        Invoke("move111", 3);
    }

    public void move111()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(0, 0, -10);
        Invoke("move1111", 3);
    }
    
    public void move1111()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(10, 0, 0);
        Invoke("move11111", 3);
    }

    public void move11111()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(0, 0, 10);
        Invoke("move11", 3);
    }

    public void move2()
    {
        rb.velocity = new Vector3(0, 0, -10);
        ismove = false;
        Invoke("move22", 1);
    }

    public void move22()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(10, 0, 0);
        Invoke("move222", 3);
    }

    public void move222()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(0, 0, 10);
        Invoke("move2222", 3);
    }

    public void move2222()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(-10, 0, 0);
        Invoke("move22222", 3);
    }

    public void move22222()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(0, 0, -10);
        Invoke("move22", 3);
    }

    public void move3()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(10, 0, 0);
        ismove = false;
        Invoke("move33", 1);
    }

    public void move33()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(0, 0, 10);
        Invoke("move333", 3);
    }

    public void move333()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(-10, 0, 0);
        Invoke("move3333", 3);
    }

    public void move3333()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(0, 0, -10);
        Invoke("move33333", 3);
    }

    public void move33333()
    {
        thisfish.transform.Rotate(0, 90, 0);
        rb.velocity = new Vector3(10, 0, 0);
        Invoke("move33", 3);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "first spawn position" && x == 0)
        {
            x = 1;
            isspawn = true;
        }
        else if(other.tag == "second spawn position" && x == 0)
        {
            x = 1;
            isspawn1 = true;
        }
        else if (other.tag == "third spawn position" && x == 0)
        {
            x = 1;
            isspawn2 = true;
        }
        if(other.tag == "hook")
        {
            rb.velocity = new Vector3(0, 0, 0);
            hooked = true;
        }
    }

}
