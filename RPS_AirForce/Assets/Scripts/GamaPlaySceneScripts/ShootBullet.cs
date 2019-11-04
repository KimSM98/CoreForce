using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject shootPos;//bullet발사 위치
    public GameObject[] EnemytBulletObjs;//bullet sprite
    public GameObject[] FireBulletObjs;//bullet sprite
    //시도
    public float public_shootTerm = 1.5f;//외부에서 조절
    //bulletNum을 TypeNum으로 바꾸기
    //TypeNum[0:Fire 1:grass 2:water]
    private int EnemyBulletNum = 0;
    private int[] TypeNum = { 0, 0, 0 };//bulletObjs 배열 번호, 0: Fire 1: grass 2: water
    private bool isEnemyshoot = false;//이것을 사용해서 쏘고 안쏘게 함
    private float shootTerm;//발사 텀

    void Start()
    {
       // bulletNum = { 0, 0, 0};//bulletObjs 배열 번호
        //shootTerm = public_shootTerm;
        shootTerm = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.CompareTag("Player"))//총알을 날리는 주체가 플레이어일때
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //bullet을 발사 위치로 이동 시킴
                FireBulletObjs[TypeNum[0]].transform.position = new Vector3(shootPos.transform.position.x, shootPos.transform.position.y, 0);
                //bullt을 이동 상태로 바꿈
                FireBulletObjs[TypeNum[0]].gameObject.GetComponent<BulletScript>().isMove = true;
                TypeNum[0]++;
                if (TypeNum[0] == FireBulletObjs.Length)//0으로 초기화
                    TypeNum[0] = 0;
            }
        }
        
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
            if (EnemyBulletNum == EnemytBulletObjs.Length)//0으로 초기화
                EnemyBulletNum = 0;
        }

        
    }
    
    public void EnemyShoot()
    {
        EnemytBulletObjs[EnemyBulletNum].transform.position = new Vector3(shootPos.transform.position.x, shootPos.transform.position.y, 0);
        EnemytBulletObjs[EnemyBulletNum].gameObject.GetComponent<BulletScript>().isMove = true;
        EnemyBulletNum++;
        isEnemyshoot = false;
    }
    /*
    IEnumerator EnemyShootingWait()
    {
        yield return new WaitForSeconds(2.0f);
        isEnemyshoot = true;
    }*/
}
