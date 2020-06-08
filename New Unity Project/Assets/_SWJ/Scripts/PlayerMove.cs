﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어 이동
    public float speed = 5.0f;      //플레이어 이동속도
    public Vector2 margin;          //뷰포트좌표는 0.0f~1.0f 사이의 값

    //조이스틱 사용하기
    public VariableJoystick joystick;   //조이스틱
    
    // Start is called before the first frame update
    void Start()
    {
        margin = new Vector2(0.08f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveInScreen();
    }

    
    private void MoveInScreen()
    {
        

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //조이스틱 사용하기
        //키보드가 안눌렀을때 => 조이스틱 사용하면 된다
        if(h==0 && v==0)
        {
            h = joystick.Horizontal;
            v = joystick.Vertical;
        }


        transform.Translate(h * speed * Time.deltaTime, v*speed*Time.deltaTime, 0);
        //Vector3 dir = Vector.right * h + Vector3.up *v;


        //위치 = 현재위치 + (방향 * 시간)
        //P = P0+vt;
        //transform.position = transform.position + (dir*speed*Time.deltaTIme);

        //방법은 크게 3가지
        //첫번째 : 화면밖의 공간에 큐브 4개 만들어서 배치
        //리지드바디의 충돌체로 이동 못하게 막기

        //두번째 : 플레이어의 포지션으로 이동처리
        //캐스팅 : x의 값을 변경하기위해 처리하는 방법, 아래와 같이 transform.position의 값을 벡터3에 담아서 계산 후
        //다시 대입시키는 과정을 캐스팅이라고 한다. 
        //Vector3 position = transform.position;
        //position.x = Mathf.Clamp(position.x, -2.5f, 2.5f);
        //position.y = Mathf.Clamp(position.y, -3.5f, 5.5f);
        //transform.position = position;

        //세번째 : 메인카메라의 뷰포트를 가져와서 처리한다(우린 이걸 사용하게 된다.)
        //스크린좌표 : 왼쪽하단(0,0), 우측상단(maxX,maxY)
        //뷰포트좌표 : 왼쪽하단(0,0), 우측상단(1.0f, 1.0f)
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp(position.x, 0.0f+margin.x, 1.0f-margin.x);
        position.y = Mathf.Clamp(position.y, 0.0f+margin.y, 1.0f-margin.y);


        transform.position = Camera.main.ViewportToWorldPoint(position);

    }
}
