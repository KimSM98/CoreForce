using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    public GameObject[] EnemyCorePos;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Enemy>().ObjectType == 0)
            EnemyCorePos[0].SetActive(true);
        else if(GetComponent<Enemy>().ObjectType == 1)
        {
            EnemyCorePos[1].SetActive(true);
            EnemyCorePos[2].SetActive(true);
        }
        else if (GetComponent<Enemy>().ObjectType == 2)
        {
            EnemyCorePos[3].SetActive(true);
            EnemyCorePos[4].SetActive(true);
            EnemyCorePos[5].SetActive(true);
        }
    }

}
