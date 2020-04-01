using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBullet : MonoBehaviour
{
    public GameObject shootPos;
  
    float public_shootTerm;
    private bool isEnemyshoot = false;
    private float shootTerm = 0;
    int type;

    void Update()
    {
        if (this.gameObject.tag == "Enemy")
        {
            if (isEnemyshoot == true)
            {
                EnemyShoot();
                shootTerm = 0;
                isEnemyshoot = false;
            }
            if(isEnemyshoot == false){
                shootTerm += Time.deltaTime;
            }
            if(shootTerm >= public_shootTerm)                
                isEnemyshoot = true;
          
        }
        
    }

    public void EnemyShoot()
    {
        
        if(this.GetComponent<Enemy>().ObjectType != 1){
            type = this.GetComponent<EnemyCore>().GetCoreProperty();
            GetComponentInParent<EnemyManager>().GetBullet(type).transform.position = new Vector2(shootPos.transform.position.x, shootPos.transform.position.y);
        }
            
        if(this.GetComponent<Enemy>().ObjectType == 1){
            if(GetComponent<Enemy>().hp <=10){
                type = this.GetComponent<EnemyCore>().GetCoreProperty();
                GetComponentInParent<EnemyManager>().GetBossSkillBullet(type).transform.position = new Vector2(shootPos.transform.position.x, shootPos.transform.position.y);
                
                type = this.GetComponent<EnemyCore>().GetCoreProperty();
                GetComponentInParent<EnemyManager>().GetBossSkillBullet(type).transform.position = new Vector2(shootPos.transform.position.x-1.15f, shootPos.transform.position.y+1f);

                type = this.GetComponent<EnemyCore>().GetCoreProperty();
                GetComponentInParent<EnemyManager>().GetBossSkillBullet(type).transform.position = new Vector2(shootPos.transform.position.x+1.0f, shootPos.transform.position.y+1f);
           
            }
            else{
                type = this.GetComponent<EnemyCore>().GetCoreProperty();
                GetComponentInParent<EnemyManager>().GetBullet(type).transform.position = new Vector2(shootPos.transform.position.x, shootPos.transform.position.y);
        
                type = this.GetComponent<EnemyCore>().GetCoreProperty();
                GetComponentInParent<EnemyManager>().GetBullet(type).transform.position = new Vector2(shootPos.transform.position.x-1.15f, shootPos.transform.position.y+1f);
            
                type = this.GetComponent<EnemyCore>().GetCoreProperty();
                GetComponentInParent<EnemyManager>().GetBullet(type).transform.position = new Vector2(shootPos.transform.position.x+1.0f, shootPos.transform.position.y+1f);
            }
            
        }
        isEnemyshoot = false;
    }

    public void SetShootTerm(float term)
    {
        public_shootTerm = term;
        if(shootTerm == 0)
            shootTerm = public_shootTerm;
    }

    public void ResetShootTerm(){
        shootTerm = public_shootTerm;
    }
 
}

