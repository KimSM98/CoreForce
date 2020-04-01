using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    public GameObject[] EnemyCores;
    int[] EnemyCoreProperty;
    int random;
    int coreType;
    
    public void OffCores(){
        for(int i=0; i < EnemyCores.Length; i++){
            EnemyCores[i].SetActive(false);
        }
    }
    public void SetActiveCorePos(int coreNum)
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

        if(coreNum == 0){
            EnemyCoreProperty[0] = Random.Range(0,3);
        }
        else if(coreNum == 1){
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
