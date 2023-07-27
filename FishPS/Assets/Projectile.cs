using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody HRB; //Harpoon Rigidbody
    private Vector3 OriginalPos; //spawn position of harpoon hook
    private Quaternion OriginalRot; //spawn rotation of harpoon hook
    // Start is called before the first frame update
    void Start()
    {
        HRB = GetComponent<Rigidbody>();
        OriginalPos = transform.position; //save original position to variable
        OriginalRot = transform.rotation; //save original rotation to variable
        //Fire();
        HRB.velocity = transform.forward * HarpoonOperation.HSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Mathf.Abs(Mathf.Sqrt(Mathf.Pow((transform.position.x - HarpoonOperation.HSpawn.transform.position.x), 2f) + Mathf.Pow((transform.position.y - HarpoonOperation.HSpawn.transform.position.y), 2f) + Mathf.Pow((transform.position.z - HarpoonOperation.HSpawn.transform.position.z), 2f))) > HarpoonOperation.range) {
        if(Vector3.Distance(OriginalPos, transform.position) > HarpoonOperation.range) {
            Debug.Log("E");
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
        //transform.position = Vector3.MoveTowards(transform.position, OriginalPos, HarpoonOperation.HSpeed * Time.deltaTime);
        HRB.velocity = Vector3.Normalize(HarpoonOperation.HSpawn.transform.position - transform.position) * (HarpoonOperation.HSpeed / 3f);
        HarpoonOperation.canFire = true;
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "red fish" || other.gameObject.tag == "teal fish" || other.gameObject.tag == "orange fish") {
            other.gameObject.transform.parent = transform.parent;
            returnToGun();
        } else if(other.gameObject.tag == "projectileDestroyer") {
            Destroy(this.gameObject);
        }
    }
}
