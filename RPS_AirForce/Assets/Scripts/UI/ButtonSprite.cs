using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSprite : MonoBehaviour
{
    public Sprite[] ButtonSpr;

    int i = 0;

    void Start()
    {
        this.GetComponent<Image>().sprite = ButtonSpr[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextSprite()
    {
        i++;
        this.GetComponent<Image>().sprite = ButtonSpr[i];
        if (i == ButtonSpr.Length)
        {
            i = 0;
        }
    }
}
