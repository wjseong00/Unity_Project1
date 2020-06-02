using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;        //총알 프리팹
    public GameObject subPet1;
    public GameObject subPet2;
    public GameObject firePoint;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Fire();
    }

    private void Fire()
    {
        //마우스 왼쪽 버튼 or 왼쪽 컨트롤 키
        if(Input.GetButtonDown("Fire1"))
        {
            //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다.
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다.

            //총알 게임오브젝트 생성
            GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트의 위치 지정
            bullet.transform.position = firePoint.transform.position;
        }
    }

    

}
