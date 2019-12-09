using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class swipe : MonoBehaviour
{
    //private int directionNum = 0;
    private Vector2 mousePosition;
    Button button1;

    Vector3 cameraView;

    void Update()
    {
        if(Input.touchCount >0)
        {
            Touch myTouch = Input.GetTouch(0);
            Drag(myTouch.position);
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

