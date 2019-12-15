using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSprite : MonoBehaviour
{
    public Sprite[] ButtonSpr;
    public int ButtonPrperty = 0; //0:Fire, 1: Grass, 2: water
    public GameObject Player;
    int count=0;
    bool isButtonfever = false;
    void Start()
    {
        this.GetComponent<Image>().sprite = ButtonSpr[0];
    }

    public void NextSprite(int num)
    {   
        if(isButtonfever == false){
            if(count<5){//문제, 줄이면 올라옴
                count++;
                this.GetComponent<Image>().sprite = ButtonSpr[count];
                //여기에서 playershootbullet의 스킬 true false를 보내줌
                //gam
            }
            if(count == 4){
                isButtonfever = true;
                Player.GetComponent<PlayerShootBullet>().SetIsButtonFever(true, ButtonPrperty);
                SoundManager.instance.ButtonFeverSound();
            } 
        }        
        
            
        
    }

    public void SetCount(int num){
        count = num;
        if(num == 0)
            isButtonfever=false;   
        
        this.GetComponent<Image>().sprite = ButtonSpr[count];
    }
}
