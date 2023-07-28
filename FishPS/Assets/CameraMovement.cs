using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public static float lookSpeed = 2f;
    [SerializeField] float VRotation;
    public static bool cursorCaptured = false;
    //public Camera Main;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //confines cursor to window
        Cursor.visible = false; //makes cursor invisible

    }
    /*public static void ChangeCursorMode()
    {
        if(cursorCaptured)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            cursorCaptured = false;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            cursorCaptured = true;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        /*if(HarpoonOperation.canFire == false) {
            lookSpeed = 0f;
        } else { 
            lookSpeed = 2f;
        }*/
        //Vector3 mPos = Input.mousePosition;
        float lookX = Input.GetAxis("Mouse X") * lookSpeed;
        float lookY = Input.GetAxis("Mouse Y") * lookSpeed;
        VRotation -= lookY;
        VRotation = Mathf.Clamp(VRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * VRotation;
        player.transform.Rotate(Vector3.up * lookX);
        //transform.LookAt(Input.mousePosition - Main.ScreenToWorldPoint(transform.position));
    }
}
