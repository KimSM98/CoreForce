using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public float moveSpeed = 10;
    public bool isMeteorAppear = false;
    public float AppearTerm;
    bool isMove = false;
    public GameObject Line;
    public GameObject Coution;

    private float xPos, yPos;
    
    void Start()
    {
        
        Line.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.4f);
        xPos = this.transform.position.x;
        yPos = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMeteorAppear == true){
            isMeteorAppear = false;
            xPos = EnemyManager.instance.GetMeteorPos();
            this.transform.position = new Vector2(xPos, yPos);

            StartCoroutine(Flicker());
        }

        if(isMove == true)
            this.transform.Translate(new Vector2(0, -moveSpeed * Time.deltaTime));
        
        if(this.transform.position.y < -5.6f){
            isMove = false;
            
            StartCoroutine(WaitAppear());
            this.transform.position = new Vector2(xPos, yPos);
        }
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){
            coll.gameObject.SetActive(false);
            GameManager.instance.isPlayerDead = true;
            SoundManager.instance.PlayerDeadSound();
        }
    }

    public void AppearMeteror(float term){
        AppearTerm = term;
        isMeteorAppear = true;
    }
    IEnumerator WaitAppear(){
        //isMeteorAppear = false;

        yield return new WaitForSeconds(AppearTerm);

        isMeteorAppear = true;

        Line.SetActive(true);
        Coution.SetActive(true);
    }
    IEnumerator Flicker(){
        
        /*for(float i= 1; i>0.5; i-=0.1f){            
            Line.GetComponent<SpriteRenderer>().color = new Color(1,1,1,i); 
        }*/
        Line.SetActive(true);

        yield return new WaitForSeconds(1f);

        /*for(float i = 0.5f; i <= 1; i+=0.1f){            
            Line.GetComponent<SpriteRenderer>().color = new Color(1,1,1,i); 
        }*/
        Line.SetActive(false);
        Coution.SetActive(false);
        
        //xPos = EnemyManager.instance.GetMeteorPos();
        //EnemyManager.instance.GetComponent<EnemyManager>().GetMeteorPos();
        
        //this.transform.position = new Vector2(EnemyManager.instance.GetMeteorPos(), yPos);

        yield return new WaitForSeconds(1f);
        
        isMove = true;
        SoundManager.instance.MeteorSound();
        //isMeteorAppear = false;
    }

}
