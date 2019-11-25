using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    public GameObject[] EnemyCorePos;

    int NumOfcore;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetActiveCorePos(int coreNum)
    {
        NumOfcore = coreNum;

        if (coreNum == 0)
        {
            Debug.Log("코어1켜주세요" + EnemyCorePos[0].transform.position.x);
            EnemyCorePos[0].SetActive(true);
            //GetComponent<EnemyManager>().GetCore().transform.position = new Vector2(EnemyCorePos[0].transform.position.x, EnemyCorePos[0].transform.position.y);
            //EnemyCorePos[0].SetActive(true);
            
        }
            
        if (coreNum == 1)
        {
            EnemyCorePos[1].SetActive(true);
            EnemyCorePos[2].SetActive(true);
        }
        if (coreNum == 2)
        {
            EnemyCorePos[3].SetActive(true);
            EnemyCorePos[4].SetActive(true);
            EnemyCorePos[5].SetActive(true);
        }
    }

}
