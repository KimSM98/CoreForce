using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//코어를 먹으면 보스 등장, 버튼 피버 게이지 증가, 스코어 증가
public class ItemScript : MonoBehaviour
{
    public int Score;
    public float CoreDropSpeed = 3f;

    public bool isMove = false;//Enemy가 죽었으면 True

    float Xpos;
    float Ypos;
    int Enemy1Num;
    public float spinSpeed = 0.5f;
    float temp;
    Vector3 cameraView;

    // Start is called before the first frame update
    void Start()
    {
        Xpos = this.transform.position.x;
        Ypos = this.transform.position.y;
        temp = spinSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        cameraView = Camera.main.WorldToViewportPoint(transform.position);
        
        if (isMove == true)
        {        
            if (cameraView.y < -0.3f){                
                Relocate();
            }//Time.deltaTime
            this.transform.Translate(new Vector2(0, -CoreDropSpeed *Time.deltaTime));
            SpinItem();
        }
        //임시
        /*if(Time.deltaTime == 0)
            spinSpeed = 0;
        else if(Time.deltaTime!=0)
            spinSpeed = temp;*/

    }
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){            
            GameManager.instance.AddScore(Score, GetComponent<ObjectTypeScript>().GetObjType());
            
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
