using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerShootBullet : MonoBehaviour
{
    public GameObject[] Bullets;
    public GameObject shootPos;//bullet발사 위치
    public GameObject PlayerCore;
    public GameObject[] Buttons;
    int bulletNum = 0;
    //작업중
    public bool[] IsButtonFeverOn;
    bool[] feverTimeDuration;
    public GameObject[] particles;
    void Start()
    {
        IsButtonFeverOn = new bool[3]{false, false, false};
        feverTimeDuration = new bool[3]{false,false,false};
        for(int i = 0; i< particles.Length; i++){
            particles[i].GetComponent<ParticleSystem>().Stop();
        }
    }

    void ShootBullet()//일반 공격
    {
        Bullets[bulletNum].GetComponent<ObjectTypeScript>().ChangeSprite();
        Bullets[bulletNum].transform.position = new Vector2(shootPos.transform.position.x, shootPos.transform.position.y);
        Bullets[bulletNum].GetComponent<BulletScript>().isMove = true;

        bulletNum++;

        if (bulletNum == Bullets.Length)
            bulletNum = 0;        
    }

    void ShootSkill(int type){
        float skillShooPos = shootPos.transform.position.x -0.6f;

            for(int i=0; i<3; i++){
                Bullets[bulletNum].GetComponent<ObjectTypeScript>().Type = type;
                Bullets[bulletNum].GetComponent<ObjectTypeScript>().ChangeSprite();
                Bullets[bulletNum].transform.position = new Vector2(skillShooPos + 0.6f*i , shootPos.transform.position.y);
                Bullets[bulletNum].GetComponent<BulletScript>().isMove = true;
                bulletNum++;

                if (bulletNum == Bullets.Length)
                    bulletNum = 0;
            }
    }

#region 미사일 발사 함수
    void ShootFire()
    {
        Bullets[bulletNum].GetComponent<ObjectTypeScript>().Type = 0;
    }

    void ShootGrass()
    {
        Bullets[bulletNum].GetComponent<ObjectTypeScript>().Type = 1;
    }

    void ShootWater()
    {
        Bullets[bulletNum].GetComponent<ObjectTypeScript>().Type = 2;
    }
#endregion

    public void Button0Shoot()
    {
        if(Time.deltaTime != 0){
           PlayerCore.GetComponent<ObjectTypeScript>().Changetype(0);
        
            if(IsButtonFeverOn[0] == false){
                if(feverTimeDuration[0] == false){
                    ShootFire();
                    ShootBullet();
                }
                else if(feverTimeDuration[0]==true)
                    ShootSkill(0);
                
            }
                
            else if(IsButtonFeverOn[0] == true){
                StartCoroutine(SkillCoroutine(0));
            } 
        }
        
            
    }
    public void Button1Shoot()
    {
        if(Time.deltaTime != 0){
           PlayerCore.GetComponent<ObjectTypeScript>().Changetype(1);        
        
            if(IsButtonFeverOn[1] == false){
                if(feverTimeDuration[1] == false){
                    ShootGrass();
                    ShootBullet();
                }
                else if(feverTimeDuration[1]==true)
                    ShootSkill(1);
                
            }
                
            else if(IsButtonFeverOn[1] == true){
                StartCoroutine(SkillCoroutine(1));
            } 
        }
        
    }
    public void Button2Shoot()
    {
        if(Time.deltaTime != 0){
           PlayerCore.GetComponent<ObjectTypeScript>().Changetype(2);

            if(IsButtonFeverOn[2] == false){
                if(feverTimeDuration[2] == false){
                    ShootWater();
                    ShootBullet();
                }
                else if(feverTimeDuration[2]==true)
                    ShootSkill(2);
            }
            
            else if(IsButtonFeverOn[2] == true){
                StartCoroutine(SkillCoroutine(2));
            } 
        }
        
    }
    public void SetIsButtonFever(bool answer, int BP){
        IsButtonFeverOn[BP] = answer;
    }
    IEnumerator SkillCoroutine(int type){
        IsButtonFeverOn[type] = false;
        feverTimeDuration[type] = true;

        StartParticle(true, type);

        yield return new WaitForSeconds(0.5f);
        Buttons[type].GetComponent<ButtonSprite>().SetCount(3);

        yield return new WaitForSeconds(0.5f);
        Buttons[type].GetComponent<ButtonSprite>().SetCount(2);

        yield return new WaitForSeconds(0.5f);
        Buttons[type].GetComponent<ButtonSprite>().SetCount(1);        

        yield return new WaitForSeconds(0.5f);        
        Buttons[type].GetComponent<ButtonSprite>().SetCount(0);
        StartParticle(false, type);        
        feverTimeDuration[type]= false;
    }

    void StartParticle(bool isStart, int type){
        if(isStart == true)
            particles[type].GetComponent<ParticleSystem>().Play();
        else if(isStart == false)
            particles[type].GetComponent<ParticleSystem>().Stop();
    }
}
