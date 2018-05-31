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
        if (PlayerPrefsX.GetBool("Square"))
            isLocked = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!isLocked)
        {
            playerIcon.SetActive(true);
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            PlayerPrefsX.SetBool("Square", true);
        }
	}
}
