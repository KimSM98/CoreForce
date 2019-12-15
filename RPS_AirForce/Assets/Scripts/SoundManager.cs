using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public GameObject[] Sounds;
    public GameObject Background;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("사운드" + PlayerPrefs.GetInt("IsSoundOn"));
    }
   void Start()
    {
        if(PlayerPrefs.GetInt("IsSoundOn") == 1)
            Background.GetComponent<AudioSource>().Play();
        instance=this;
    }

    // Update is called once per frame
    public void OnSound(){//사운드 켬
        PlayerPrefs.SetInt("IsSoundOn", 1);
        Background.GetComponent<AudioSource>().Play();
        //SoundManager.SetActive(true);
    }
    public void OffSound(){//사운드 끔
        PlayerPrefs.SetInt("IsSoundOn", 0);
        Background.GetComponent<AudioSource>().Stop();
        //SoundManager.SetActive(false);
    }
    public void ClickSound(){
        
        if(PlayerPrefs.GetInt("IsSoundOn") == 1)
            Sounds[0].GetComponent<AudioSource>().Play();
    }

    public void AttackSound(){
        if(PlayerPrefs.GetInt("IsSoundOn") == 1)
            Sounds[1].GetComponent<AudioSource>().Play();
    }
    
    public void PickUpCoreSound(){
        if(PlayerPrefs.GetInt("IsSoundOn") == 1)
            Sounds[2].GetComponent<AudioSource>().Play();
    }

    public void EnemyDeadSound(){
        if(PlayerPrefs.GetInt("IsSoundOn") == 1)
            Sounds[3].GetComponent<AudioSource>().Play();
    }

    public void PlayerDeadSound(){
        if(PlayerPrefs.GetInt("IsSoundOn") == 1){
            Sounds[4].GetComponent<AudioSource>().Play();
        }
        Background.GetComponent<AudioSource>().Stop();
    }

    public void ButtonFeverSound(){
        if(PlayerPrefs.GetInt("IsSoundOn") == 1){
            Sounds[5].GetComponent<AudioSource>().Play();
        }
    }

    public void MeteorSound(){
        if(PlayerPrefs.GetInt("IsSoundOn") == 1){
            Sounds[6].GetComponent<AudioSource>().Play();
        }
    }

    public void BossAppearSound(){
        if(PlayerPrefs.GetInt("IsSoundOn") == 1){
            Sounds[7].GetComponent<AudioSource>().Play();
        }
    }

}
