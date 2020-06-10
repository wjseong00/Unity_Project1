using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //위에서 아래로 떨어지기만 한다 (똥피하기 느낌)
    //충돌처리 (에너미랑 플레이어, 에너미랑 플레이어 총알)


    public float speed = 10.0f;
    public int killScore = 0;

    public GameObject fxfactory;
    public GameObject beFactory;
    // Update is called once per frame
    void Update()
    {
        //아래로 이동해라
        transform.Translate(speed * Time.deltaTime * Vector3.down);
        
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        //자기자신도 없애고
        //충돌된 오브젝트도 없앤다
        Destroy(gameObject);
        //Destroy(collision.gameObject);
        if (collision.gameObject.name.Contains("Bullet"))
        {
            collision.gameObject.SetActive(false);
            GameObject be = Instantiate(beFactory);
            be.transform.position = collision.transform.position;
            Destroy(be, 0.5f);
        }
        //if (collision.gameObject.name.Contains("Bullet"))
        //{
        //    //충돌 오바젝트는 비활성화 시킨다
        //    collision.gameObject.SetActive(false);
        //    //오브젝트풀에 추가만 해준다
        //    PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
        //    pf.bulletPool.Enqueue(collision.gameObject);
        //    GameObject be = Instantiate(beFactory);
        //    be.transform.position = collision.transform.position;
        //    Destroy(be, 0.5f);
        //}

        //이펙트보여주기
        ShowEffect();

        HighScore.instance.ScoreBoard();
        
    }
    void ShowEffect()
    {
        GameObject fx = Instantiate(fxfactory);
        fx.transform.position = transform.position - new Vector3(0,1.5f,0);
        
        Destroy(fx, 1.0f);
    }
}
