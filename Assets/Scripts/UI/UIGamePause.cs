using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGamePause : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] Button pauseButton;

    private void Start()
    {
        closeButton.onClick.AddListener(CloseButtonClick);
    }
    public void MainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void CloseButtonClick()
    {
        gameObject.SetActive(false);
    }
}
