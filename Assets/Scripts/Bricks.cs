using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

    public GameObject BrickParticles;

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(BrickParticles, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
