using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyManager : MonoBehaviour {

    public GameObject obstacle;
    GameObject[] obstacles;
    public int maxObstacles;


	// Use this for initialization
	void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Time.timeScale = 0;
        Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
        obstacles = GameObject.FindGameObjectsWithTag("FlappyLines");
        if (obstacles.Length < maxObstacles)
        {
            obstacles = GameObject.FindGameObjectsWithTag("FlappyLines");
            Vector2 lastObstacle = new Vector2(obstacles[0].transform.position.x + 5f, 0);
            Instantiate(obstacle, lastObstacle, Quaternion.Euler(0, 0, 90)).transform.parent = gameObject.transform.parent; ;
        }
        InvokeRepeating("CreateNewObstacle",0,1);
	}

    void CreateNewObstacle()
    {
        obstacles = GameObject.FindGameObjectsWithTag("FlappyLines");
        if (obstacles.Length < maxObstacles)
        {
            Vector2 lastObstacle = new Vector2(obstacles[obstacles.Length - 1].transform.position.x + 5f, 0);
            Instantiate(obstacle, lastObstacle, Quaternion.Euler(0, 0, 90)).transform.parent = gameObject.transform.parent; ;
        }
    }
}
