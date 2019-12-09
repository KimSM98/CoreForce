using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//코어를 먹으면 보스 등장, 버튼 피버 게이지 증가, 스코어 증가
public class ItemScript : MonoBehaviour
{
    public int Score;
    public float CoreDropSpeed = 0.5f;

    public bool isMove = false;//Enemy가 죽었으면 True

    float Xpos;
    float Ypos;
    int Enemy1Num;
    int spinSpeed =1;
    Vector3 cameraView;

    // Start is called before the first frame update
    void Start()
    {
        Xpos = this.transform.position.x;
        Ypos = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        cameraView = Camera.main.WorldToViewportPoint(transform.position);
        
        if (isMove == true)
        {        
            this.transform.Translate(new Vector2(0, CoreDropSpeed * -0.1f));
            SpinItem();

            if (cameraView.y < -0.3f){
                /*this.transform.position = new Vector2(Xpos, Ypos);
                isMove = false;*/
                Relocate();
            }
        }

    }
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){            
            GameManager.instance.AddScore(Score, GetComponent<ObjectTypeScript>().GetObjType());
            
            Relocate();

        }
    }

    void SpinItem(){
        if(transform.localScale.x >= 1 || transform.localScale.x <= 0)
            spinSpeed *= -1;
        transform.localScale += new Vector3(0.05f*spinSpeed,0,0);
    }

    void Relocate(){
        this.gameObject.SetActive(false);
        this.transform.position = new Vector2(Xpos, Ypos);
        this.gameObject.SetActive(true);
        isMove=false;
    }

}
