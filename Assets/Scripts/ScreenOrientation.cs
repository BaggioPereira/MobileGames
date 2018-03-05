using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientation : MonoBehaviour {

    public bool Landscape, Portrait;

    void Start()
    {
        if (Landscape)
            Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;

        if (Portrait)
            Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
    }
}
