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

            if (cameraView.y < -0.3f){
                this.transform.position = new Vector2(Xpos, Ypos);
                isMove = false;
            }
        }

    }
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){            
            GameManager.instance.AddScore(Score, GetComponent<ObjectTypeScript>().GetObjType());
            //GetComponent<GameManager>().AddPropertyCount(GetComponent<ObjectTypeScript>().GetObjType());
            //.AddPropertyCount(GetComponent<ObjectTypeScript>().GetObjType());
            Relocate();

        }
    }

    void Relocate(){
        this.gameObject.SetActive(false);
        this.transform.position = new Vector2(Xpos, Ypos);
        this.gameObject.SetActive(true);
    }

}
