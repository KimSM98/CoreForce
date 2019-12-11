using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public void SaveScore(int score){
        if(score > PlayerPrefs.GetInt("BestScore") || PlayerPrefs.HasKey("BestScore") == false){
            PlayerPrefs.SetInt("BestScore", score); 
        }
            
    }

    public int LoadBestScore(){
        return PlayerPrefs.GetInt("BestScore");
    }
}
