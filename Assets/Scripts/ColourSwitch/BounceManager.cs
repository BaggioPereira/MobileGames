using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BounceManager : MonoBehaviour {

    public GameObject Cube;
    public GameObject InitalChanger;
    private Vector2 touchOrigin = -Vector2.one;
    BackButton back;
    public float score = 0;

    public Text text;

    float width;
    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1;
        back = FindObjectOfType<BackButton>();
        if (InitalChanger != null)
            Time.timeScale = 0;
        width = Screen.width;
    }
}
