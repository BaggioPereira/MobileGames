using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyMover : MonoBehaviour {

    public float speed = 100;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
        if (transform.position.x < -10f)
            Destroy(gameObject);
    }
}
