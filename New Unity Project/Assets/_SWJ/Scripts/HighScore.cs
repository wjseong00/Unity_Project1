using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //유니티엔진의 GUI에 접근가능
using TMPro;        //텍스트메시프로 사용시
public class HighScore : MonoBehaviour
{


    public Text HighScoreText;
    public Text killScoreText;
    public int killScore = 0;
    public int highScore = 0;

    public static HighScore instance = null;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        killScore = 0;
        highScore = PlayerPrefs.GetInt("HighS");
        killScoreText.text = string.Format("{0}", killScore.ToString("0000"));
        HighScoreText.text = string.Format("{0}", highScore.ToString("0000"));
        //ScoreBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetScore()
    {
        killScore = 0;
        killScoreText.text = string.Format("{0}", killScore.ToString("0000"));
        HighScoreText.text = string.Format("{0}", highScore.ToString("0000"));
    }
    
    

    public void ScoreBoard()
    {
        
        killScore++;
        killScoreText.text = string.Format("{0}", killScore.ToString("0000"));
        HighScoreText.text = string.Format("{0}", highScore.ToString("0000"));
        if (highScore<=killScore)
        {
            highScore++;
        }
        PlayerPrefs.SetInt("HighS", highScore);
    }
}
