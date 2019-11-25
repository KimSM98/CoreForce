using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTypeScript : MonoBehaviour
{
    public int Type = 0; //Misail 0:Fire 1:Grass 2:Water//Enemy 0: Core1, 1: Core2, 2: Core3
    public Sprite[] Sprites;

    int collType=0;
    
    public void ChangeSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = Sprites[Type];
    }

    public int GetObjType(){
        return Type;
    }

    /*private void OnTriggerEnter2D(Collider2D coll)
    {
        if(this.CompareTag("PlayerBullet"))
        {
            if(coll.CompareTag("EnemyBullet"))
            {
                collType = coll.GetComponent<ObjectTypeScript>().Type;
                if(IsWin(Type, collType) == true)
                {
                    Debug.Log("미사일 승리");
                    coll.gameObject.SetActive(false);
                    coll.GetComponent<BulletScript>().SetBulletPos();
                }
            }
        }
    }*/

    
}
