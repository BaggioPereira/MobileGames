using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongManager : MonoBehaviour {
    PingPongMover[] walls;
    ColourSwitchBall player;
	// Use this for initialization
	void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Time.timeScale = 0;
        Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
        walls = GameObject.FindObjectsOfType<PingPongMover>();
        player = GameObject.FindObjectOfType<ColourSwitchBall>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player.score > 9)
        {
            for (int i = 0; i < walls.Length; i++)
            {
                if (!walls[i].pingpong)
                    walls[i].pingpong = true;
            }
        }
	}
}
