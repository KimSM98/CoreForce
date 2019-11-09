using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTypeScript : MonoBehaviour
{
    public int Type = 0; //1:Fire 2:Grass 3:Water//
    public Sprite[] Sprites;
    
    public void ChangeSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = Sprites[Type];
    }
}
