using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        if(SceneManager.GetActiveScene().name != "Colour Switch")
            Time.timeScale = 1;
        Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
