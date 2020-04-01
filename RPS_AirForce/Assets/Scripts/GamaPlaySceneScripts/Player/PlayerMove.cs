using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Vector2 mousePosition;    
    Touch myTouch;
    
    void Update()
    {
        Drag(Input.mousePosition);

        if(Input.touchCount >0)//for Android
        {
            myTouch = Input.GetTouch(0);
            Drag(myTouch.position);
            
        }
    }
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Enemy")){
            this.gameObject.SetActive(false);
            GameManager.instance.isPlayerDead = true;
            SoundManager.instance.PlayerDeadSound();
        }
    }
    public void Drag(Vector2 pos)
    {
        mousePosition = pos;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if(-1.1f< mousePosition.x && mousePosition.x <= 2.5f &&  mousePosition.y < 4f)
            this.transform.position = new Vector2(mousePosition.x, this.transform.position.y);
    }

}

