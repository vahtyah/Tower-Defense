using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] Button pauseButton;
    [SerializeField] GameObject gamePausePanel;
    [SerializeField] UIGameOver UIGameOver;
    [SerializeField] UIGameComplete UIGameComplete;
    Player player;
    private void Start()
    {
        player = Player.instance;
        pauseButton.onClick.AddListener(PauseButtonClick);
        UIGameOver.Init();
        UIGameComplete.Init();
        SetCostText();
        SetLivesText();
        UnitEvent();
    }

    void UnitEvent()
    {
        player.OnChangeMoney += (object sender, EventArgs eventArgs) =>
        {
            SetCostText();
        };
        player.OnChangeLives += (object sender, EventArgs eventArgs) =>
        {
            SetLivesText();
        };
    }

    void SetCostText()
    {
        costText.text = "$" + player.GetMoney().ToString();
    }

    void SetLivesText()
    {
        livesText.text = player.GetLives().ToString() + " Lives";
    }

    void PauseButtonClick()
    {
        gamePausePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
