using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelController : MonoBehaviour
{
    [SerializeField] private RectTransform pausePanel;
    [SerializeField] private RectTransform loosePanel;
    [SerializeField] private UIScoreText scoreText;

    public static UIPanelController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        pausePanel.gameObject.SetActive(false);
        loosePanel.gameObject.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        Time.timeScale = 0;
        pausePanel.gameObject.SetActive(true);
    }

    public void ShowLooseMenu()
    {
        loosePanel.gameObject.SetActive(true);
    }

    public void GetScore(int score)
    {
        scoreText.GetScore(score);
    }
}
