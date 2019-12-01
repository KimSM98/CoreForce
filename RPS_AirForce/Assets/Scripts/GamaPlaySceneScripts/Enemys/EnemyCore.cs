using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    public GameObject[] EnemyCores;
    //int[] EnemyCoreProperty = {0,0,0};
    int[] EnemyCoreProperty;
    int random;
    int coreType;
    void Start()
    {
        //OffCores();
    }
    
    public void OffCores(){//Enemy의 속성 개수가 바뀌면 끔
        for(int i=0; i < EnemyCores.Length; i++){
            EnemyCores[i].SetActive(false);
        }
    }
    public void SetActiveCorePos(int coreNum)//추후에 이름 바꿀 것//Enemy 속성 개수
    {
        SetCoreProperties(coreNum);
        coreType=0;
        if(GetComponent<Enemy>().ObjectType == 0){
            for(int i=coreNum; i<coreNum*2+1; i++){
                EnemyCores[i].GetComponent<ObjectTypeScript>().Changetype(EnemyCoreProperty[coreType]);
                coreType++;
                EnemyCores[i].SetActive(true);
            }        
        }
        
    }

    void SetCoreProperties(int coreNum){
        EnemyCoreProperty = new int[coreNum+1];

        if(coreNum !=2){
            for(int i=0; i < coreNum+1; i++){
            EnemyCoreProperty[i] = GetComponentInParent<EnemyManager>().GetEnemyCoreProperty();
            }
        }
        else if(coreNum == 2){
            for(int i=0; i < coreNum+1; i++){
            EnemyCoreProperty[i] = i;
            }
        }


    }

    public int GetCoreProperty(){
        random = Random.Range(0,EnemyCoreProperty.Length);
        return EnemyCoreProperty[random];
    }

    public int[] GetEnemyCorePropertyArr(){
        return EnemyCoreProperty;
    }

}
