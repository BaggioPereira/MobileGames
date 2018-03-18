using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesMover : MonoBehaviour {

    public GameObject[] lines;
    public float speed = 100f;
    public bool reverse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (!reverse)
            {
                lines[i].transform.position = new Vector3(lines[i].transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
                if (lines[i].transform.position.x < -8f)
                    lines[i].transform.position = new Vector3(lines[i].transform.position.x + 16f, lines[i].transform.position.y, lines[i].transform.position.z);
            }

            else if (reverse)
            {
                lines[i].transform.position = new Vector3(lines[i].transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
                if (lines[i].transform.position.x > 8f)
                    lines[i].transform.position = new Vector3(lines[i].transform.position.x - 16f, lines[i].transform.position.y, lines[i].transform.position.z);
            }
        }
	}
}
