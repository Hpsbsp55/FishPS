using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class displayprice : MonoBehaviour
{

    public UIManager amountofmoney;
    public int displaymoney;
    public TextMeshProUGUI mytext;
    
    
    

    void Start()
    {
        displaymoney = -2000;
        
    }

    
    void Update()
    {
        displaymoney = amountofmoney.Getcurrentmoney();
        mytext.text = displaymoney.ToString();

        if (displaymoney >= 0)
        {
            SceneManager.LoadScene("Win Scene");
        }
    }
}
