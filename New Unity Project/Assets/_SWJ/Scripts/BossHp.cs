using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{

    public static BossHp instance = null;
    public GameObject bFxFactory;
    public int bossHp = 25;
    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        //인스턴스가 널일 경우
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if(bossHp<=0)
        {
            GameObject bFx = Instantiate(bFxFactory);
            bFx.transform.position = GameObject.Find("Boss").transform.position - new Vector3(0,1.0f,0);
            Destroy(bFx,3.0f);
            Destroy(GameObject.Find("Boss").gameObject);
            
        }
    }

    public void BossHit()
    {
        bossHp--;
        
    }
}
