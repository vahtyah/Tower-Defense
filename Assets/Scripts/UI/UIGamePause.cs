using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGamePause : MonoBehaviour
{
    public void MainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void CloseButtonClick()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
