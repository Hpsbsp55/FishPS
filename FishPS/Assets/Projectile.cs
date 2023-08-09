using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody HRB; //Harpoon Rigidbody
    private Vector3 OriginalPos; //spawn position of harpoon hook
    private Quaternion OriginalRot; //spawn rotation of harpoon hook
    private GameObject fish; //initialize fish gameObject
    private bool fishInTow = false;
                             // Start is called before the first frame update

    //public UIManager manager = new UIManager();

    // UI Game Object
    //GameObject FishUIPopUp;
    void Start()
    {
        HRB = GetComponent<Rigidbody>();
        OriginalPos = transform.position; //save original position to variable
        OriginalRot = transform.rotation; //save original rotation to variable
        //Fire();
        HRB.velocity = transform.forward * HarpoonOperation.HSpeed;
        //FishUIPopUp = GameObject.FindGameObjectWithTag("PopUp");
        //Debug.Log(FishUIPopUp);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(OriginalPos, transform.position) > HarpoonOperation.range * Mathf.Pow(Powerups.rangeIncrement, Powerups.rangeFactor)) {
            //Debug.Log("E");
            returnToGun();
        }
        if(fishInTow)
        {
            fish.GetComponent<Rigidbody>().velocity = HRB.velocity;
        }
    }
    void returnToGun() {
        GameObject player = GameObject.FindGameObjectWithTag("projectileDestroyer");
        HRB.velocity = Vector3.Normalize(player.transform.position - transform.position) * (HarpoonOperation.HSpeed * Mathf.Pow(Powerups.speedIncrement, Powerups.speedFactor) / 2f); //set the harpoon's velocity
        if (fish != null) {
            //fish.GetComponent<Rigidbody>().velocity = HRB.velocity; //set the fish's velocity to the harpoon's velocity
            fishInTow = true;
        }
    }
    void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.name);
        //Quaternion fishR;
        //Vector3 fishS;
        if (other.gameObject.tag == "red fish")
        {
            fish = other.gameObject; //get fish gameobject
            /*Powerups.rangeTimer += 30f;
            Powerups.rangeFactor += 1f;*/
            returnToGun(); //run the returnToGun
        } else if (other.gameObject.tag == "teal fish") {
            fish = other.gameObject; //get fish gameobject
            /*Powerups.speedTimer += 30f;
            Powerups.speedFactor += 1f;*/
            returnToGun(); //run the returnToGun
        } else if (other.gameObject.tag == "orange fish") {
            fish = other.gameObject; //get fish gameobject
            /*Powerups.spawnTimer += 30f;
            Powerups.spawnFactor += 1f;*/
            returnToGun(); //run the returnToGun
        } else if(other.gameObject.tag == "projectileDestroyer") {
            

            if (fish != null)
            {
                Debug.Log(CameraMovement.cursorCaptured);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                Debug.Log(CameraMovement.cursorCaptured);
                Debug.Log(fish.tag);
                if (fish.tag != null) {
                    string ftag = fish.tag;
                    ftag = ftag.Substring(0, ftag.IndexOf(" "));
                    Debug.Log(ftag);
                    UIManager.Instance.summonUI(ftag);
                }
                /*
                if (fish.tag == "red fish")
                {
                    UIManager.Instance.summonUI("red");
                }
                else if (fish.tag == "teal fish")
                {
                    UIManager.Instance.summonUI("teal");
                }
                else if (fish.tag == "orange fish")
                {
                    UIManager.Instance.summonUI("orange");
                }*/
                Destroy(fish);
            }
            Destroy(this.gameObject);
            HarpoonOperation.canFire = true;
        }
    }
}
