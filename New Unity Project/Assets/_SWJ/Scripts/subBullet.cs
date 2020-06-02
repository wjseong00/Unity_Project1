using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subBullet : MonoBehaviour
{
    public GameObject bulletFactory;        //총알 프리팹

    public GameObject firePoint;

    bool shoot = true;
    // Start is called before the first frame update
    private void OnEnable()
    {
        shoot = true;
    }
    void Start()
    {
        //StartCoroutine("subFire");
        
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

        GameObject bullet = Instantiate(bulletFactory);
        //총알 오브젝트의 위치 지정
        bullet.transform.position = firePoint.transform.position;
        yield return new WaitForSeconds(0.5f);

        shoot = true;
        
    }
}
