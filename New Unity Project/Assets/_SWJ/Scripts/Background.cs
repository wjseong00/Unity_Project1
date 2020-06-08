using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    
    public Material mat;        //백그라운드 메터리얼
    public float scrollSpeed=0.1f;      //스크롤 속도
    
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        //speed += Time.deltaTime;
        BackgroundScroll();
    }

    void BackgroundScroll()
    {
        //아래와 같은걸 캐스팅이라고 한다
        //transform.Translate 보정할때랑 똑같음 
        //메터리얼의 메인텍스쳐 오프셋은 Vector2로 만들어져 있다
        Vector2 offset = mat.mainTextureOffset;
        //offset.y의 값만 보정해주면된다
        offset.Set(0, offset.y + (scrollSpeed * Time.deltaTime));
        //다시 메테리얼 오프셋에 담는다.
        mat.mainTextureOffset = offset;
        
    }
}
