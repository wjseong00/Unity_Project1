using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subBullet : MonoBehaviour
{
    public GameObject bulletFactory;        //총알 프리팹

    public GameObject firePoint;

    bool shoot = true;
    int fireIndex = 0;
    int poolSize = 20;
    //1. 배열
    //GameObject[] bulletPool;
    //2. 리스트
    public List<GameObject> bulletPool;
    // Start is called before the first frame update
    private void OnEnable()
    {
        shoot = true;
    }
    void Start()
    {
        //StartCoroutine("subFire");
        bulletPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory, GameObject.Find("SubBullet").transform);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(shoot)
        {
            StartCoroutine("subFire");
            
        }
    }

    IEnumerator subFire()
    {
        shoot = false;

        bulletPool[fireIndex].SetActive(true);
        bulletPool[fireIndex].transform.position = firePoint.transform.position;
        bulletPool[fireIndex].transform.up = firePoint.transform.up;
        fireIndex++;
        if (fireIndex >= poolSize) fireIndex = 0;
        yield return new WaitForSeconds(0.5f);

        shoot = true;
        
    }
}
