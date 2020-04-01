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

        yield return new WaitForSeconds(AppearTerm);

        isMeteorAppear = true;

        Line.SetActive(true);
        Coution.SetActive(true);
    }
    IEnumerator Flicker(){
        
        Line.SetActive(true);
        yield return new WaitForSeconds(1f);

        Line.SetActive(false);
        Coution.SetActive(false);      
        yield return new WaitForSeconds(1f);     

        isMove = true;
        SoundManager.instance.MeteorSound();
    }

}
