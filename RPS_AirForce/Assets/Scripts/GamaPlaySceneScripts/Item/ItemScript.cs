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
        /*
        if (cameraView.y < -0.3f)//카메라 밖에 나가면, 움직임을 멈추고 원래 있던 자리로
        {//몬스터가 죽어서 플레이어가 먹었을때 사용?
            //isMove = false;
            //this.transform.position = new Vector2(Xpos, Ypos);
            GetEnemyPos();
        }*/

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
        Debug.Log("Coll1");
        if(coll.CompareTag("Player")){
            Debug.Log("Coll2");
            GameManager.instance.AddScore(Score);

            Relocate();

        }
    }

    void Relocate(){
        this.gameObject.SetActive(false);
        this.transform.position = new Vector2(Xpos, Ypos);
        this.gameObject.SetActive(true);
    }

}
