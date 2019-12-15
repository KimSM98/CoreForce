using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTypeScript : MonoBehaviour
{
    public int Type = 0; //Misail 0:Fire 1:Grass 2:Water//Enemy 0: Core1, 1: Core2, 2: Core3
    public Sprite[] Sprites;

    void Start()
    {
        ChangeSprite();
    }
    public void ChangeSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = Sprites[Type];
    }
    public void Changetype(int type){
        Type = type;        
        ChangeSprite();
    }

    public int GetObjType(){
        return Type;
    }


}
