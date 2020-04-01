using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemScript : MonoBehaviour
{
    public int Score;
    public float CoreDropSpeed = 3f;
    public bool isMove = false;

    float Xpos;
    float Ypos;
    int Enemy1Num;
    public float spinSpeed = 0.5f;
    float temp;
    Vector3 cameraView;

    void Start()
    {
        Xpos = this.transform.position.x;
        Ypos = this.transform.position.y;
        temp = spinSpeed;
    }

    void Update()
    {
        cameraView = Camera.main.WorldToViewportPoint(transform.position);
        
        if (isMove == true)
        {        
            if (cameraView.y < -0.3f){                
                Relocate();
            }
            this.transform.Translate(new Vector2(0, -CoreDropSpeed *Time.deltaTime));
            SpinItem();
        }      

    }
    
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){            
            GameManager.instance.AddScore(Score);
            GameManager.instance.AddPropertyCount(GetComponent<ObjectTypeScript>().GetObjType());
            SoundManager.instance.PickUpCoreSound();
            Relocate();

        }
    }

    void SpinItem(){
        
        transform.localScale += new Vector3(spinSpeed * 0.1f,0,0);
    
        if(transform.localScale.x > 1 || transform.localScale.x < 0)
            spinSpeed *= -1;
            
    }

    void Relocate(){
        this.gameObject.SetActive(false);
        this.transform.position = new Vector2(Xpos, Ypos);
        this.gameObject.SetActive(true);
        isMove=false;
    }

}
