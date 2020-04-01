using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeUIScript : MonoBehaviour
{
    public Sprite[] Sprites;
    public void ChangeImage(int type){  
        this.GetComponent<Image>().sprite = Sprites[type];
    }
}
