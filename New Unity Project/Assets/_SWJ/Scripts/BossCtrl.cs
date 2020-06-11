using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    //보스 총알발사 (총알패턴)
    //1. 플레이어를 향해서 총알발사
    //2. 회전총알 발사
    
    public GameObject bulletFactory;        //총알 프리팹
    public GameObject firePos;
    public GameObject playerRt;
    public GameObject beFactory;
 
    public float curTime = 0;
    public float fireTime = 1;

    public float fireTime1 = 1.5f;     //1.5초에 한번씩 총알 발사
    public float curTime1 =0.0f;
    public int bulletMax = 10;
    
    


    // Update is called once per frame
    void Update()
    {
        //Fire();

        AutoFire1();
        AutoFire2();
    }
    //플레이어를 향해서 총알 발사
    private void AutoFire2()
    {
        if(playerRt !=null)
        {
            curTime += Time.deltaTime;
            if (curTime > fireTime)
            {
                //총알 공장에서 총알 생성
                GameObject bullet = Instantiate(bulletFactory);
                //총알 생성 위치
                bullet.transform.position = transform.position;
                //플레이어를 향하는 방향 구하기(벡터의 뺄샘)
                Vector3 dir = playerRt.transform.position - transform.position;
                dir.Normalize();
                //총구의 방향도 맞춰준다(이게 중요함)
                bullet.transform.up = dir;
                curTime = 0.0f;
            }
        }
        
    }

    //회전 총알 발사
    private void AutoFire1()
    {
        if (playerRt != null)
        {
            curTime1 += Time.deltaTime;
            if (curTime1 > fireTime1)
            {
                for (int i = 0; i < bulletMax; i++)
                {
                    //총알 공장에서 총알 생성
                    GameObject bullet = Instantiate(bulletFactory);
                    //총알 생성 위치
                    bullet.transform.position = transform.position;
                    //플레이어를 향하는 방향 구하기(벡터의 뺄샘)
                    //350도 방향으로 총알 발사
                    float angle = 360.0f / bulletMax;
                    //총구의 방향도 맞춰준다(이게 중요함)
                    bullet.transform.eulerAngles = new Vector3(0,0,i*angle);
                }
                
                curTime1 = 0.0f;
            }
        }
    }

    void Fire()
    {
        curTime += Time.deltaTime;
        if (curTime > fireTime)
        {
            //누적된 현재시간을 0.0초로 초기화(반드시 해줘야 한다)
            curTime = 0.0f;



            Quaternion rot = Quaternion.LookRotation(playerRt.transform.position - firePos.transform.position);
            firePos.transform.rotation =rot*Quaternion.Euler(90,0,0);
            GameObject bullet = Instantiate(bulletFactory,firePos.transform.position,firePos.transform.rotation);
           
            
           

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            BossHp.instance.BossHit();
            collision.gameObject.SetActive(false);
            GameObject be = Instantiate(beFactory);
            be.transform.position = collision.transform.position;
            Destroy(be, 0.5f);
        }
    }
}
