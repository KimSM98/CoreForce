using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    public GameObject[] EnemyCores;
    public int[] EnemyCoreProperty;
    void Start()
    {
        //OffCores();
    }
    
    void OffCores(){//Enemy의 속성 개수가 바뀌면 끔
        for(int i=0; i < EnemyCores.Length; i++){
            EnemyCores[i].SetActive(false);
        }
    }

    
    public void SetActiveCorePos(int coreNum)//Enemy 속성 개수
    {
        if (coreNum == 0)
        {
            EnemyCores[0].SetActive(true);
            EnemyCores[0].GetComponent<ObjectTypeScript>().Changetype(GetComponentInParent<EnemyManager>().GetEnemyCoreProperty());
        
        }
            
        if (coreNum == 1)
        {
            EnemyCores[1].SetActive(true);
            EnemyCores[2].SetActive(true);
            EnemyCores[1].GetComponent<ObjectTypeScript>().Changetype(GetComponentInParent<EnemyManager>().GetEnemyCoreProperty());
            EnemyCores[2].GetComponent<ObjectTypeScript>().Changetype(GetComponentInParent<EnemyManager>().GetEnemyCoreProperty());
            Debug.Log("222");
        }
        if (coreNum == 2)
        {
            EnemyCores[3].SetActive(true);
            EnemyCores[4].SetActive(true);            
            EnemyCores[5].SetActive(true);
        }
    }

    public void SetCoreProperties(int coreNum, int propertyNum){
        
    }

}
