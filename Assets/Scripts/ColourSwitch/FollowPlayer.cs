using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public GameObject canvas;
    GameObject[] pastObstacles;

	// Use this for initialization
	void Start ()
    {
        pastObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        canvas = GameObject.Find("OverlayGO");
	}
	
	// Update is called once per frame
	void Update ()
    {
        pastObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        if (player != null)
        {
            if (player.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
                canvas.transform.position = new Vector3(transform.position.x, transform.position.y + 1.75f, transform.position.z);
            }
        }

        for(int i = 0; i < pastObstacles.Length; i++)
        {
            if (pastObstacles[i].transform.position.y < transform.position.y -10f)
                if(pastObstacles[i].transform.parent != null)
                    Destroy(pastObstacles[i].transform.parent.gameObject);
                else
                    Destroy(pastObstacles[i]);
        }
	}
}
