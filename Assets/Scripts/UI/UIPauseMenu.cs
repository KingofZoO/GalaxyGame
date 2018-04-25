using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseMenu : MonoBehaviour
{
    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void Continue()
    {
        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
