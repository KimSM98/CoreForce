using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScript : MonoBehaviour
{
    void Awake()
    {
        //Screen.SetResolution(Screen.width, (Screen.width * 16) / 9 , true);
        Screen.SetResolution(1080, 1920, true);
    
    }
}
