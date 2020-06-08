﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;        //총알 프리팹
    public GameObject subPet1;
    public GameObject subPet2;
    public GameObject firePoint;

    //레이저를 발사하기 위해서는 라인렌더러가 필요하다
    //선은 최소 2개의 점이 필요하다(시작점, 끝점)
    LineRenderer lr;     //라인렌더러 컴포넌트
    float curTime = 0.0f;
    float FireTime = 1.0f;
    float timer = 0.0f;
    float rayTime = 0.5f;
    //private RaycastHit hit;
    //Ray ray;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //라인렌더러 컴포넌트 추가
        lr = GetComponent<LineRenderer>();
        //중요!!!
        //게임오브젝트는 활성화 비활성화 => SetActive() 함수 사용
        //컴포넌트는 enabled 속성 사용
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            
            count++;
            if(count >2)
            {
                count = 2;
            }
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            count--;
            if(count<0)
            {
                count = 0;
            }
        }
        if(count ==1)
        {
            subPet1.SetActive(true);
            subPet2.SetActive(false);
        }
        else if(count ==2)
        {
            subPet1.SetActive(true);
            subPet2.SetActive(true);
        }
        else if(count ==0)
        {
            subPet1.SetActive(false);
            subPet2.SetActive(false);
        }
        //Fire();
        //FireRay();
        //레이저를 보여준다
        //일정 시간이 지나면 레이저 보여주는기능비활성화

        if (lr.enabled) showLayer();
        //if(lr.enabled)
        //{
        //    curTime += Time.deltaTime;
        //    if(curTime >FireTime)
        //    {
        //        lr.enabled = false;
        //    }
        //}
        
        
    }
    void showLayer()
    {
        if (lr.enabled)
        {
            timer += Time.deltaTime;
            if (timer >rayTime)
            {
                lr.enabled = false;
            }
        }
    }
    //레이저 발사
    public void FireRay()
    {
        //마우스 왼쪽 버튼 or 왼쪽 컨트롤 키
        if (Input.GetButtonDown("Fire1"))
        {
            curTime = 0;
            timer = 0;
            //라인렌더러 컴포넌트 활성화
            lr.enabled = true;
            //라인 시작점, 끝점
            //Vector3 pos = transform.position;
            //lr.SetPosition(0, transform.position);
            //ray = new Ray(transform.position, Vector3.up * 10);
            //Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
            //Debug.Log("포인트 : " + hit.point);
            //if (Physics.Raycast(ray, out hit, 10))
            //{
            //    if(hit.collider.name =="Boss")
            //    {
            //        Debug.Log("IN");
            //        lr.SetPosition(1, hit.point);
            //    }
            //    else
            //    {
            //        lr.SetPosition(1, transform.position + Vector3.up * 10);
            //    }
            //    
            //}
            //else
            //{
            //    lr.SetPosition(1, transform.position + Vector3.up * 10);
            //}
            lr.SetPosition(0, transform.position);
            //라인의 끝점은 충돌된 지점으로 변경한다.
            Ray ray = new Ray(transform.position, Vector3.up);
            RaycastHit hitInfo; //Ray의 충돌된 오브젝트의 정보를 담는다.
            if(Physics.Raycast(ray,out hitInfo))
            {
                //레이저의 끝점 지정
                lr.SetPosition(1, hitInfo.point);
                //충돌된 오브젝트 모두 지우기
                Destroy(hitInfo.collider.gameObject);

                //디스토리존의 탑과는 충돌처리 되지 않도록 한다.
                if(hitInfo.collider.name != "Top")
                {
                    Destroy(hitInfo.collider.gameObject);
                }

                //충돌된 에너미 오브젝트 삭제
                //Contains("Enemy") => Enemy(clone) 이런것도포함함
                //if (hitInfo.collider.name.Contains("Enemy"))
                //{
                //    Destroy(hitInfo.collider.gameObject);
                //}
            }
            else
            {
                //충돌된 오브젝트가 없으니 끝점을 정해준다.
                lr.SetPosition(1, transform.position + Vector3.up * 10);
            }
        }
    }

    


    //총알 발사
    public void Fire()
    {
        //마우스 왼쪽 버튼 or 왼쪽 컨트롤 키
        //if(Input.GetButtonDown("Fire1"))
        {
            //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다.
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다.

            //총알 게임오브젝트 생성
            GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트의 위치 지정
            bullet.transform.position = firePoint.transform.position;
        }
    }

    //버튼 클릭으로 공격 발사
    public void OnFireButtonClikc()
    {
        //총알 게임오브젝트 생성
        GameObject bullet = Instantiate(bulletFactory);
        //총알 오브젝트의 위치 지정
        bullet.transform.position = firePoint.transform.position;
    }
}
