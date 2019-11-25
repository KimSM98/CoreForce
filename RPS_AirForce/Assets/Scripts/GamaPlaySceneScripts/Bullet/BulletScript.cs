using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletSpeed = 1f;
    public bool isMove = false;

    float Xpos;
    float Ypos;
    int thisType;
    int collType;
    bool isDraw = false;
    Vector3 cameraView;

    void Start()
    {        
        //처음 위치
        Xpos = this.transform.position.x;
        Ypos = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlayerDead == true)//Gameover상황이면
        {
            if (this.CompareTag("EnemyBullet") == true)//EnemyBullet이 안보이게
            {
                this.gameObject.SetActive(false);//끔
            }
        }

        cameraView = Camera.main.WorldToViewportPoint(transform.position);
        
        if(this.gameObject.tag == "EnemyBullet")//Enemy불렛일때
        {
            if (cameraView.y < 0f)//카메라 밖에 나가면, 움직임을 멈추고 원래 있던 자리로
            {
                isMove = false;
                this.transform.position = new Vector2(Xpos, Ypos);
            }
            /*if (isMove == true)
            {
                this.transform.Translate(new Vector2(0, BulletSpeed * 0.1f));//아래로 이동
            }*/
        }
        else//Player불렛일때
        {     
            if (cameraView.y > 1f)//카메라 밖에 나가면, 움직임을 멈추고 원래 있던 자리로
            {
                isMove = false;
                this.transform.position = new Vector2(Xpos, Ypos);
            }/*
            if (isMove == true)
                this.transform.Translate(new Vector2(0, BulletSpeed * 0.1f));//위로 이동
       */
        }
        if (isMove == true)
            this.transform.Translate(new Vector2(0, BulletSpeed * 0.1f));//위로 이동



    }

    void OnTriggerEnter2D(Collider2D coll)
    {        
        if(this.CompareTag("PlayerBullet")){
            if(coll.CompareTag("EnemyBullet")){
                thisType = this.GetComponent<ObjectTypeScript>().GetObjType();
                collType = coll.GetComponent<ObjectTypeScript>().GetObjType();

                if(IsWin(thisType, collType) == true){
                    coll.GetComponent<BulletScript>().SetBulletPos();
                }
                else
                {
                    if(isDraw == true){
                        coll.GetComponent<BulletScript>().SetBulletPos();
                        isDraw = false;
                    }                        
                    SetBulletPos();
                }
            }

            if(coll.CompareTag("Enemy")){
                SetBulletPos();
                coll.gameObject.GetComponent<Enemy>().isEnemyLive = false;
                GameManager.instance.playerScore += 100;
            }

        }
        if(this.CompareTag("EnemyBullet")){
            if(coll.CompareTag("Player")){
                coll.gameObject.SetActive(false);                
                GameManager.instance.isPlayerDead = true;//player죽음 
            }
        }

       

        /* 
        //부딪힌게 뭐든지간에 총알을 숨김/Enemy끼지 부딪히면 없어지지 않게 한다
        this.gameObject.SetActive(false);
        //this.transform.position = new Vector2(Xpos, Ypos);
        SetBulletPos();
        this.gameObject.SetActive(true);

        if (this.gameObject.tag != "EnemyBullet")//Bullet이 PlayerBullet일때
        {
            if (coll.gameObject.tag == "Enemy")//Bullet에 맞은게 Enemy일때
            {
                Debug.Log("coll is Enemy");

                //아래; enemy가 파괴된 것 처럼            
                //다시 위로 이동(x좌표 다른 곳으로) 
                coll.gameObject.GetComponent<Enemy>().isEnemyLive = false;
                
                //추가-Enemy종류마다 점수
                GameManager.instance.playerScore += 100;
            }
        }
        else if (this.gameObject.tag == "EnemyBullet")
        {
            //player와 부딪히면 게임 오버
            if (coll.gameObject.tag == "Player")//Bullet에 맞은게 Player일때
            {
                coll.gameObject.SetActive(false);
                
                GameManager.instance.isPlayerDead = true;//player죽음                
            }
        } */
       
    }

    bool IsWin(int thisType, int collType)//상성 체크
    {
        //이김
        if (thisType == 0 && collType == 1 || thisType == 1 && collType == 2 || thisType == 2 && collType == 0)
        {
            return true;
        }
        else if(thisType == collType)
            isDraw = true;

        return false;
    }    

    public void SetBulletSpeed(float speed)
    {
        BulletSpeed = speed;
    }

    public void SetBulletPos()
    {
        this.transform.position = new Vector2(Xpos, Ypos);
    }

    

}
