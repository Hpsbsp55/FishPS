using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public static float rangeTimer = 0f;
    public static float rangeFactor = 0f;
    public static float rangeIncrement = 0f;
    public static float speedTimer = 0f;
    public static float speedFactor = 0f;
    public static float speedIncrement = 0f;
    public static float spawnTimer = 0f;
    public static float spawnFactor = 0f;
    public static float spawnIncrement = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rangeTimer > 0f)
            rangeTimer -= Time.deltaTime;
        if (speedTimer > 0f)
            speedTimer -= Time.deltaTime;
        if (spawnTimer > 0f)
            spawnTimer -= Time.deltaTime;
    }
}
