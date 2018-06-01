using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locked : MonoBehaviour {
    public bool isLocked = true;
    public GameObject playerIcon;
	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefs.GetInt(playerIcon.name) == 1)
            isLocked = false;
        Unlock();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Unlock()
    {
        if(!isLocked)
        {
            playerIcon.SetActive(true);
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            PlayerPrefs.SetInt(playerIcon.name, 1);
        }

        else if(isLocked)
        {
            playerIcon.SetActive(false);
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }
}
