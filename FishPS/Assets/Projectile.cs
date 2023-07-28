using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody HRB; //Harpoon Rigidbody
    private Vector3 OriginalPos; //spawn position of harpoon hook
    private Quaternion OriginalRot; //spawn rotation of harpoon hook
    private GameObject fish; //initialize fish gameObject
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
        UIManager.Instance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Mathf.Abs(Mathf.Sqrt(Mathf.Pow((transform.position.x - HarpoonOperation.HSpawn.transform.position.x), 2f) + Mathf.Pow((transform.position.y - HarpoonOperation.HSpawn.transform.position.y), 2f) + Mathf.Pow((transform.position.z - HarpoonOperation.HSpawn.transform.position.z), 2f))) > HarpoonOperation.range) {
        if(Vector3.Distance(OriginalPos, transform.position) > HarpoonOperation.range) {
            //Debug.Log("E");
            returnToGun();
        }
        //Debug.Log(Mathf.Abs(Mathf.Sqrt(Mathf.Pow((transform.position.x - HarpoonOperation.HSpawn.transform.position.x), 2f) + Mathf.Pow((transform.position.y - HarpoonOperation.HSpawn.transform.position.y), 2f) + Mathf.Pow((transform.position.z - HarpoonOperation.HSpawn.transform.position.z), 2f))));
    }
    //public void Fire() {
    //HRB.AddRelativeForce(Vector3.forward * HarpoonOperation.HSpeed);
    //while(Mathf.Sqrt(Mathf.Pow(transform.position.x - HarpoonOperation.HSpawn.transform.position.x, 2f) + Mathf.Pow(transform.position.y - HarpoonOperation.HSpawn.transform.position.y, 2f) + Mathf.Pow(transform.position.z - HarpoonOperation.HSpawn.transform.position.z, 2f)) < HarpoonOperation.range) {
    //    continue;
    //}
    //while(Vector3.Distance(OriginalPos, transform.position) < HarpoonOperation.range) {
    //    continue;
    //}
    //HRB.velocity = new Vector3(0, 0, 0);
    //HRB.AddRelativeForce();
    //returnToGun();
    //HarpoonOperation.canFire = true;
    //}
    void returnToGun() {

        //FishUIPopUp = GameObject.Find("PopUp");
        //transform.position = Vector3.MoveTowards(transform.position, OriginalPos, HarpoonOperation.HSpeed * Time.deltaTime);
        HRB.velocity = Vector3.Normalize(HarpoonOperation.HSpawn.transform.position - transform.position) * (HarpoonOperation.HSpeed / 3f); //set the harpoon's velocity
        if (fish != null) {
            fish.GetComponent<Rigidbody>().velocity = HRB.velocity; //set the fish's velocity to the harpoon's velocity
            /* (fish.tag == "red fish")
            {
                UIManager.Instance.summonUI("red");
            } else if (fish.tag == "teal fish")
            {
                UIManager.Instance.summonUI("teal");
            } else if (fish.tag == "orange fish")
            {   
                UIManager.Instance.summonUI("orange");
            }*/
        }
        //HarpoonOperation.canFire = true;
    }
    void OnTriggerEnter(Collider other) {
        //Quaternion fishR;
        //Vector3 fishS;
        if(other.gameObject.tag == "red fish" || other.gameObject.tag == "teal fish" || other.gameObject.tag == "orange fish") {
            //fish = other.transform;
            /*fishP = other.gameObject.transform.position;
            fishR = other.gameObject.transform.rotation;
            fishS = other.gameObject.transform.localScale;

            other.gameObject.transform.parent = transform;
            //other.transform = fish;
            other.gameObject.transform.position = fishP;
            other.gameObject.transform.rotation = fishR;
            other.gameObject.transform.localScale = fishS;*/
            fish = other.gameObject; //get fish gameobject
            //other.GetComponent<Rigidbody>().velocity = Vector3.Normalize(HarpoonOperation.HSpawn.transform.position - transform.position) * (HarpoonOperation.HSpeed / 3f); //set the fish's velocity the same way that the harpoon's velocity is set
            returnToGun(); //run the returnToGun
        } else if(other.gameObject.tag == "projectileDestroyer") {

            if (fish != null)
            {
                Debug.Log(CameraMovement.cursorCaptured);
                CameraMovement.ChangeCursorMode();
                Debug.Log(CameraMovement.cursorCaptured);
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
                }
                Destroy(fish);
            }
            Destroy(this.gameObject);
            HarpoonOperation.canFire = true;
        }
    }
}
