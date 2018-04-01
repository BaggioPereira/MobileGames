using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;

    GameObject[] pastObstacles;

	// Use this for initialization
	void Start ()
    {
        pastObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
	}
	
	// Update is called once per frame
	void Update ()
    {
        pastObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        if (GameObject.Find("Player") != null)
        {
            if (player.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
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
