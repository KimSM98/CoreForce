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
        }
        else//Player불렛일때
        {     
            if (cameraView.y > 0.95f)//카메라 밖에 나가면, 움직임을 멈추고 원래 있던 자리로
            {
                isMove = false;
                this.transform.position = new Vector2(Xpos, Ypos);
            }
        }
        if (isMove == true)
            this.transform.Translate(new Vector2(0, BulletSpeed * Time.deltaTime));//위로 이동



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
                if(coll.GetComponent<Enemy>().ObjectType != 1)
                    coll.gameObject.GetComponent<Enemy>().isEnemyLive = false;
                    
                if(coll.GetComponent<Enemy>().ObjectType == 1){
                    coll.GetComponent<Enemy>().SubBossHp();
                }
                GameManager.instance.playerScore += 100;
            }

        }
        if(this.CompareTag("EnemyBullet")){
            if(coll.CompareTag("Player")){
                coll.gameObject.SetActive(false);                
                GameManager.instance.isPlayerDead = true;//player죽음 
            }
        }
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
