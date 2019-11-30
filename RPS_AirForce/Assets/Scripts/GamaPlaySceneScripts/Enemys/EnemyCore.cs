using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    public GameObject[] EnemyCores;
    //int[] EnemyCoreProperty = {0,0,0};
    int[] EnemyCoreProperty;
    int numOfCoreProperty = 0;
    int random;
    void Start()
    {
        //OffCores();
    }
    
    void OffCores(){//Enemy의 속성 개수가 바뀌면 끔
        for(int i=0; i < EnemyCores.Length; i++){
            EnemyCores[i].SetActive(false);
        }
    }
    public void SetActiveCorePos(int coreNum)//추후에 이름 바꿀 것//Enemy 속성 개수
    {
        numOfCoreProperty = coreNum;
        SetCoreProperties(coreNum);

        if (coreNum == 0)
        {
            //SetCoreProperties(coreNum);
            EnemyCores[0].GetComponent<ObjectTypeScript>().Changetype(EnemyCoreProperty[0]);

            EnemyCores[0].SetActive(true);
        }
            
        if (coreNum == 1)
        {
            //SetCoreProperties(coreNum);
            EnemyCores[1].GetComponent<ObjectTypeScript>().Changetype(EnemyCoreProperty[0]);
            EnemyCores[2].GetComponent<ObjectTypeScript>().Changetype(EnemyCoreProperty[1]);            
            
            EnemyCores[1].SetActive(true);
            EnemyCores[2].SetActive(true);
        }
        if (coreNum == 2)
        {            
            EnemyCores[3].GetComponent<ObjectTypeScript>().Changetype(0);
            EnemyCores[4].GetComponent<ObjectTypeScript>().Changetype(1);
            EnemyCores[5].GetComponent<ObjectTypeScript>().Changetype(2);

            EnemyCores[3].SetActive(true);
            EnemyCores[4].SetActive(true);            
            EnemyCores[5].SetActive(true);


        }
    }

    void SetCoreProperties(int coreNum){
        EnemyCoreProperty = new int[coreNum+1];
        //EnemyCoreProperty[coreNum] = GetComponentInParent<EnemyManager>().GetEnemyCoreProperty();
        
        for(int i=0; i < coreNum+1; i++){
            EnemyCoreProperty[i] = GetComponentInParent<EnemyManager>().GetEnemyCoreProperty();
        }
    }

    public int GetCoreProperty(){
        random = Random.Range(0,EnemyCoreProperty.Length);
        /*
        corePropertyNum++;
        
        if(corePropertyNum == EnemyCoreProperty.Length)
            corePropertyNum = 0;

        return EnemyCoreProperty[corePropertyNum];*/
        return EnemyCoreProperty[random];
    }

    public int[] GetEnemyCorePropertyArr(){
        return EnemyCoreProperty;
    }

}
