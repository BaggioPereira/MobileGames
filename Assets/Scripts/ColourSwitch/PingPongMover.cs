using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMover : MonoBehaviour {

    public GameObject[] lines;
    public float speed = 100f;
    public bool pingpong;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (pingpong)
            {
                lines[i].transform.position = new Vector3(transform.position.x, lines[i].transform.position.y - (speed * Time.deltaTime), transform.position.z);
                if (lines[i].transform.position.y < -9f)
                    lines[i].transform.position = new Vector3(lines[i].transform.position.x, lines[i].transform.position.y + 20f, lines[i].transform.position.z);
            }
        }
    }
}
