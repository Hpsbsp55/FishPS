using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    // Game Objects
    public GameObject mainCamera;


    void Start()
    {
        mainCamera.transform.position = new Vector3(1.5f, 0.7f, 1.5f);
    }

    //  Button Functions
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
