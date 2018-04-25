using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : MonoBehaviour
{
    private Text scoreText;
    private int score = 0;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        if (Time.frameCount % 10 == 0)
            scoreText.text = score.ToString();
    }

    public void GetScore(int score)
    {
        this.score += score;
    }
}
