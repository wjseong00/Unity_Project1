using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonEvent : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneMgr.instance.LoadScene("GameScene");
    }

    public void OnMenuButtonClick()
    {

    }

    public void OnOptionButtonClick()
    {

    }
}
