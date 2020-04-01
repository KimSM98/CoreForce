using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerShootBullet : MonoBehaviour
{
    public GameObject[] Bullets;
    public GameObject shootPos;
    public GameObject PlayerCore;
    public GameObject[] Buttons;
    public GameObject[] ButtonFeverParticles;

    bool[] IsButtonFeverOn;
    bool[] feverTimeDuration;  
    int bulletNum = 0;

    void Start()
    {
        IsButtonFeverOn = new bool[3]{false, false, false};
        feverTimeDuration = new bool[3]{false,false,false};
        for(int i = 0; i< ButtonFeverParticles.Length; i++){
            ButtonFeverParticles[i].GetComponent<ParticleSystem>().Stop();
        }
    }

    void Update()
    {
        //keyboard input
        if(Input.GetKeyDown(KeyCode.A))
            ButtonShoot(0);
        if(Input.GetKeyDown(KeyCode.S))
            ButtonShoot(1);
        if(Input.GetKeyDown(KeyCode.D))
            ButtonShoot(2);   
    }

    void ShootBullet()
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

            for(int i=0; i<3; i++){ //Shoot triple bullet
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

    public void ButtonShoot(int num)
    {
        SoundManager.instance.ShootBulletSound();
        if(Time.deltaTime != 0){
           PlayerCore.GetComponent<ObjectTypeScript>().Changetype(num);
        
            if(IsButtonFeverOn[num] == false){
                if(feverTimeDuration[num] == false){
                    Bullets[bulletNum].GetComponent<ObjectTypeScript>().Type = num;
                    ShootBullet();
                }
                else if(feverTimeDuration[num]==true)
                    ShootSkill(num);
                
            }
                
            else if(IsButtonFeverOn[num] == true){
                StartCoroutine(SkillCoroutine(num));
            } 
        }
    }
    //for Android - button attack
    public void ShootFire()
    {
        ButtonShoot(0);
    }

    public void ShootGrass()
    {
        ButtonShoot(1);
    }

    public void ShootWater()
    {
        ButtonShoot(2);
    }
    
#endregion

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
            ButtonFeverParticles[type].GetComponent<ParticleSystem>().Play();
        else if(isStart == false)
            ButtonFeverParticles[type].GetComponent<ParticleSystem>().Stop();
    }
}
