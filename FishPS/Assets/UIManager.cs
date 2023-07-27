using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Fish Image References
    public Sprite redFish;
    public Sprite orangeFish;
    public Sprite tealFish;

    // Fish Texts References
    string OFText = "You caught an Orange Fish!";
    string RFText = "You caught an Red Fish!";
    string TFText = "You caught an Teal Fish!";

    // UI Widgets
    public Image fishImage;
    public TMP_Text fishText;
    public GameObject sellButton;
    public GameObject eatButton;

    // The Current Fish (Used for buttons)
    public string currentFish;

    
    void Start()
    {
        gameObject.SetActive(false);
    }


    public void summonUI(string fish)
    {
        // Sets Public Fish to Summoned Fish
        currentFish = fish;

        // Setting Fish-Dependent UI
        if (fish == "red")
        {
            fishImage.sprite = redFish;
            fishText.text = RFText;
        }
        else if (fish == "orange")
        {
            fishImage.sprite = orangeFish;
            fishText.text = OFText;
        }
        else if (fish == "teal")
        {
            fishImage.sprite = tealFish;
            fishText.text = TFText;
        }

        // Showing UI
        gameObject.SetActive(true);
    }

    public void EatFish(){
        // Different Fish Options
        if (currentFish == "red")
        {
            Debug.Log("Red Fish Eaten");
        }
        else if (currentFish == "orange")
        {
            Debug.Log("Orange Fish Eaten");
        }
        else if (currentFish == "teal")
        {
            Debug.Log("Teal Fish Eaten");
        }

        //Hiding UI
        gameObject.SetActive(false);
    }


    public void SellFish(){
        // Different Fiosh Options
        if (currentFish == "red")
        {
            Debug.Log("Red Fish Sold");
        }
        else if (currentFish == "orange")
        {
            Debug.Log("Orange Fish Sold");
        }
        else if (currentFish == "teal")
        {
            Debug.Log("teal Fish Sold");
        }

        //Hiding UI
        gameObject.SetActive(false);
    }
}
