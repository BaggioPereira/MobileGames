using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnFood : MonoBehaviour
{

    // Food Prefab
    public GameObject foodPrefab;
    public int maxFood;
    int foodCounter;
    int cyan, yellow, pink, magenta;
    public Color[] foodColour;
    Vector3 location;


    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;
    Snake snake;

    // Use this for initialization
    void Start()
    {
        snake = FindObjectOfType<Snake>();
        // Spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 0, 2);
    }

    // Spawn one piece of food
    void Spawn()
    {
        cyan = GameObject.FindGameObjectsWithTag("Cyan").Length;
        //Debug.Log(cyan);
        yellow = GameObject.FindGameObjectsWithTag("Yellow").Length;
        //Debug.Log(yellow);
        pink = GameObject.FindGameObjectsWithTag("Pink").Length;
        //Debug.Log(pink);
        magenta = GameObject.FindGameObjectsWithTag("Magenta").Length;
        //Debug.Log(magenta);
        foodCounter = cyan + yellow + pink + magenta;
        if (foodCounter < maxFood)
        {
            location = RandomLocation();

            foreach(var foodObj in FindObjectsOfType(typeof(GameObject))as GameObject[])
            {
                if(foodObj.name == "FoodPrefab")
                {
                    if(foodObj.transform.position == location)
                    {
                        location = RandomLocation();
                    }
                }
            }

            // Instantiate the food at (x, y)
            GameObject food = Instantiate(foodPrefab, location, Quaternion.identity); // default rotation
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

        if (foodCounter == maxFood)
        {
            if (cyan == 0 || yellow == 0 || pink == 0 || magenta == 0)
            {
                snake.SnakeColourChange();
            }
        }
    }

    Vector2 RandomLocation()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x + 2f, borderRight.position.x - 2f);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y + 2f, borderTop.position.y - 2f);

        return new Vector3(x, y,0);
    }
}