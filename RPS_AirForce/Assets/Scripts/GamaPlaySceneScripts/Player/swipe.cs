using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    //private int directionNum = 0;
    private Vector2 mousePosition;

    Vector3 cameraView;

    void Update()
    {
       OnMouseDrag();
    }

    void OnMouseDrag()
    {
        Drag();
        
    }

    void Drag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if(-2.2f<=mousePosition.x && mousePosition.x <= 2.2f)
            this.transform.position = new Vector2(mousePosition.x, this.transform.position.y);

    }

}

