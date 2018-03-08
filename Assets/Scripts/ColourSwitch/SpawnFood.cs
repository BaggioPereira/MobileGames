using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

    // Food Prefab
    public GameObject foodPrefab;
    public int maxFood;
    int foodCounter;
    int cyan, yellow, pink, magenta;
    public Color[] foodColour;


    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Use this for initialization
    void Start()
    {
        // Spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 0, 2);
    }

    // Spawn one piece of food
    void Spawn()
    {
        cyan = GameObject.FindGameObjectsWithTag("Cyan").Length;
        yellow = GameObject.FindGameObjectsWithTag("Yellow").Length;
        pink = GameObject.FindGameObjectsWithTag("Pink").Length;
        magenta = GameObject.FindGameObjectsWithTag("Magenta").Length;
        foodCounter = cyan + yellow + pink + magenta;
        if (foodCounter < maxFood)
        {
            // x position between left & right border
            int x = (int)Random.Range(borderLeft.position.x + 2f, borderRight.position.x - 2f);

            // y position between top & bottom border
            int y = (int)Random.Range(borderBottom.position.y + 2f, borderTop.position.y - 2f);

            // Instantiate the food at (x, y)
            GameObject food = Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity); // default rotation
            int colour = Random.Range(0, foodColour.Length);
            food.GetComponent<Renderer>().material.color = foodColour[colour];
            if (colour == 0)
                food.tag = "Cyan";
            if (colour == 1)
                food.tag = "Yellow";
            if (colour == 2)
                food.tag = "Pink";
            if (colour == 3)
                food.tag = "Magenta";
        }
    }
}
