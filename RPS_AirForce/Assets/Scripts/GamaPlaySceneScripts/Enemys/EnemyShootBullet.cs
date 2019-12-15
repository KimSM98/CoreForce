using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBullet : MonoBehaviour
{
    public GameObject shootPos;//bullet발사 위치
  
    float public_shootTerm;//외부에서 조절

    private bool isEnemyshoot = false;//이것을 사용해서 쏘고 안쏘게 함
    private float shootTerm = 0;//발사 텀
    int type;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //수정 예정
        if (this.gameObject.tag == "Enemy")
        {
            if (isEnemyshoot == true)
            {
                EnemyShoot();//발사
                shootTerm = 0;//초기화
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
                GetComponentInParent<EnemyManager>().GetSkillBullet(type).transform.position = new Vector2(shootPos.transform.position.x, shootPos.transform.position.y);
                
                type = this.GetComponent<EnemyCore>().GetCoreProperty();
                GetComponentInParent<EnemyManager>().GetSkillBullet(type).transform.position = new Vector2(shootPos.transform.position.x-1.15f, shootPos.transform.position.y+1f);

                type = this.GetComponent<EnemyCore>().GetCoreProperty();
                GetComponentInParent<EnemyManager>().GetSkillBullet(type).transform.position = new Vector2(shootPos.transform.position.x+1.0f, shootPos.transform.position.y+1f);
           
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
            shootTerm = public_shootTerm;//발사
    }

    public void ResetShootTerm(){
        shootTerm = public_shootTerm;
    }
   /* IEnumerator EnemyShooting()
    {
        isEnemyshoot = true;
        yield return new WaitForSeconds(public_shootTerm);
        Debug.Log("Eshoot");
        //isEnemyshoot = true;
        EnemyShoot();
        
    }*/
}

