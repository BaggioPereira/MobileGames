using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicManager : MonoBehaviour {

    public GameObject[] obstaclePrefabs;
    GameObject[] obstacles;
    public int maxObstacles;
    // Use this for initialization
    void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Time.timeScale = 0;
        Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        if(obstacles.Length < maxObstacles)
        {
            obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            Vector2 lastObstacle = new Vector2(0, obstacles[obstacles.Length - 1].transform.position.y + 7.5f);
            int choice = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[choice], lastObstacle, Quaternion.identity).transform.parent = gameObject.transform.parent;
        }
        InvokeRepeating("CreateNewObstacle", 0, 1);
    }

    void CreateNewObstacle()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        if (obstacles.Length < maxObstacles)
        {
            Vector2 lastObstacle = new Vector2(0, obstacles[obstacles.Length - 1].transform.position.y + 7.5f);
            int choice = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[choice], lastObstacle, Quaternion.identity).transform.parent = gameObject.transform.parent;
        }
    }
}
