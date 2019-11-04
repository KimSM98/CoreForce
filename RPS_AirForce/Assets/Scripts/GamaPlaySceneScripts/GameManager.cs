using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//추가- 게임 오버되면 Enemy안보이게
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isPlayerDead = false;//플레이어가 살아있는지의 여부
    public int playerScore = 0;
    public bool isMoveOn = true;//움직이는 상황인지 체크

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isPlayerDead = false;//게임이 시작될때 초기화        
        isMoveOn = true;//시작할때는 움직임ON

        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerDead == true)//player가 죽으면
        {
            //구름 움직이게, Enemy안보이게
        }
    }
}
