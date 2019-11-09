using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBullet : MonoBehaviour
{
    public GameObject shootPos;//bullet발사 위치
    public GameObject[] EnemytBulletObjs;//bullet sprite

    public float public_shootTerm = 1.5f;//외부에서 조절

    private int bulletNum=0;//bulletObjs 배열 번호

    private bool isEnemyshoot = false;//이것을 사용해서 쏘고 안쏘게 함
    private float shootTerm;//발사 텀

    void Start()
    {
        bulletNum = 0;//bulletObjs 배열 번호
        //shootTerm = public_shootTerm;
        //shootTerm = 0f;//??????
    }

    // Update is called once per frame
    void Update()
    {
        //수정 예정
        if (this.gameObject.tag == "Enemy")
        {

            if (isEnemyshoot == true)
            {
                EnemyShoot();//발사
                shootTerm = public_shootTerm;//초기화
            }
            if (shootTerm > 0)//0보다 크면
            {
                shootTerm -= Time.deltaTime;

            }
            //Debug.Log(shootTerm);

            if (shootTerm <= 0)
            {
                isEnemyshoot = true;
            }
        }
        /*
        if (bulletNum == EnemytBulletObjs.Length)//0으로 초기화
            bulletNum = 0;
            */

    }

    public void EnemyShoot()
    {        
        EnemytBulletObjs[bulletNum].transform.position = new Vector3(shootPos.transform.position.x, shootPos.transform.position.y, 0);
        EnemytBulletObjs[bulletNum].gameObject.GetComponent<BulletScript>().isMove = true;
        bulletNum++;
        if (bulletNum == EnemytBulletObjs.Length)//0으로 초기화
            bulletNum = 0;
        isEnemyshoot = false;
    }

    IEnumerator EnemyShooting()
    {
        isEnemyshoot = true;
        yield return new WaitForSeconds(public_shootTerm);
        Debug.Log("Eshoot");
        //isEnemyshoot = true;
        EnemyShoot();
        
    }
}

