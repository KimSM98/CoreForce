using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public static BulletScript instance;
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
        
        Xpos = this.transform.position.x;
        Ypos = this.transform.position.y;
        instance = this;
    }

    void Update()
    {
        if (GameManager.instance.isPlayerDead == true)//Gameover Situation
        {
            if (this.CompareTag("EnemyBullet") == true)
            {
                this.gameObject.SetActive(false);
            }
        }

        cameraView = Camera.main.WorldToViewportPoint(transform.position);
        
        if(this.gameObject.tag == "EnemyBullet")
        {
            if (cameraView.y < 0f)
            {
                isMove = false;
                this.transform.position = new Vector2(Xpos, Ypos);
            }
        }
        else
        {     
            if (cameraView.y > 0.95f)
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

                GameManager.instance.AddScore(100);
                SoundManager.instance.EnemyDeadSound();
            }

        }
        if(this.CompareTag("EnemyBullet")){
            if(coll.CompareTag("Player")){
                coll.gameObject.SetActive(false);                
                GameManager.instance.isPlayerDead = true;
                SoundManager.instance.PlayerDeadSound(); 
            }
        }
    }

    bool IsWin(int thisType, int collType)
    {
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
