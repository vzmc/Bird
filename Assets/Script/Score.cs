using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scorePoint;
    private Text scoreText;

    void Start()
    {
        scorePoint = 0;
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "Score: " + scorePoint.ToString();
    }
}
