using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Endingシーンの処理
public class EndingControl : MonoBehaviour
{
    public Text HighScoreText;
    public Text ScoreText;
    private int highScore;
    private int score;

    void Start()
    {
        //Scoreの処理
        score = PlayerPrefs.GetInt("Score");
        highScore = PlayerPrefs.GetInt("HighScore");

        if (highScore < score)
        {
            //ScoreがHighScoreを超えると、新しいHighScoreにする
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        ScoreText.text = "Score : " + score;
        HighScoreText.text = "HighScore : " + highScore;
    }
}
