using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAnimation : MonoBehaviour {

    void LoadScene()
    {
        SceneManager.LoadScene("Colour Switch Menu", LoadSceneMode.Single);
    }
}
