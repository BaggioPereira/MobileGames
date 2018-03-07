using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicManager : MonoBehaviour {

    public GameObject[] obstacles;
    GameObject[] obstaclesCount;
    public int maxObstacles;
    // Use this for initialization
    void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Time.timeScale = 0;
        Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
        obstaclesCount = GameObject.FindGameObjectsWithTag("Obstacle");
        if (obstaclesCount.Length < maxObstacles)
        {
            int obstacleSelected = Random.Range(0, obstacles.Length);
            obstaclesCount = GameObject.FindGameObjectsWithTag("Obstacle");
            Vector2 lastObstacle = new Vector2(0, obstaclesCount[0].transform.position.y + 5f);
            Instantiate(obstacles[obstacleSelected], lastObstacle, Quaternion.identity);
        }
        InvokeRepeating("CreateNewObstacle", 0, 1);
    }

    void CreateNewObstacle()
    {
        obstaclesCount = GameObject.FindGameObjectsWithTag("Obstacle");
        if (obstacles.Length < maxObstacles)
        {
            int obstacleSelected = Random.Range(0, obstacles.Length);
            Vector2 lastObstacle = new Vector2(0, obstaclesCount[obstaclesCount.Length - 1].transform.position.y + 5f);
            Instantiate(obstacles[obstacleSelected], lastObstacle, Quaternion.identity);
        }
    }
}
