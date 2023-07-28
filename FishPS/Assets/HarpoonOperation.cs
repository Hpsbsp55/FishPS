using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonOperation : MonoBehaviour
{
    public static GameObject HSpawn; //Harpoon spawn
    [SerializeField] GameObject HPrefab; //Harpoon prefab
    //public int ROF; //Rate of fire
    public static float HSpeed; //speed of harpoon
    public static bool canFire; //is the harpoon loaded? if so, this should be true. If it has been fired, false.
    public static int range; //range of harpoon
    // Start is called before the first frame update
    void Start()
    {
        HSpawn = GameObject.FindGameObjectsWithTag("Harpoon Spawn")[0];
        HSpeed = 30f;
        range = 30;
        canFire = true;
        Debug.Log(HSpawn + "\n" + HSpeed + "\n" + range + "\n" + canFire);
        //ROF = 5; // how many seconds to reload
        UIManager.Instance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire) { //if harpoon can be fired
            CheckInput();
        }
    }
    void CheckInput() {
        if(Input.GetMouseButtonDown(0)) { //if left mouse button is pressed
            if (!CameraMovement.cursorCaptured)
            {
                CameraMovement.cursorCaptured = true;
            }
            else
            {
                canFire = false; //set canFire to false
                                 //CameraMovement.lookSpeed = 0f;
                GameObject H; //initialize local harpoon variable
                H = Instantiate(HPrefab, HSpawn.transform.position, HSpawn.transform.rotation); //instantiate the harpoon aligned with the gun
            }
        }
    }
}
