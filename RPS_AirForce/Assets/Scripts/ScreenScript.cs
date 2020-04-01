using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScript : MonoBehaviour
{
    void Awake()
    {
        Screen.SetResolution(1080, 1920, true);    
    }
}
