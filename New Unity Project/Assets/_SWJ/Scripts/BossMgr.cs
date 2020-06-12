using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMgr : MonoBehaviour
{
    public Material bg;
    public GameObject boss;
    private void Start()
    {
       
        bg = GameObject.Find("BackGround").GetComponent<MeshRenderer>().material;
    }
    private void Update()
    {
        if(bg.mainTextureOffset.y > 3.0f && bg.mainTextureOffset.y <3.2f)
        {
            boss.SetActive(true);
        }
    }
}
