using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float speed = 100f;
    public float rotationCounter;
    public bool pingpong;
    public bool reverse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!pingpong)
        {
            Rotate();
        }

        else if(pingpong)
        {
            Rotate();
            rotationCounter = transform.rotation.z;
            if (rotationCounter < 0f)
            {
                reverse = !reverse;
            }
        }
    }

    void Rotate()
    {
        if (!reverse)
            transform.Rotate(0f, 0f, speed * Time.deltaTime);

        else if (reverse)
            transform.Rotate(0f, 0f, -speed * Time.deltaTime);
    }
}
