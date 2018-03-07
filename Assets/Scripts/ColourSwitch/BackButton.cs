using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

    bool pause = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyUp(KeyCode.Escape))
        {
            string sceneName = SceneManager.GetActiveScene().name;
            if(sceneName == "Colour Switch Flappy")
            {
                if (!pause)
                {
                    pause = !pause;
                    Time.timeScale = 0;
                }
                else
                    SceneManager.LoadScene("Colour Switch", LoadSceneMode.Single);
            }
        }
	}
}
