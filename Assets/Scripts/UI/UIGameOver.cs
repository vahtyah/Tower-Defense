using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : UIGamePause
{
    public void Init()
    {
        Player.instance.OnPlayerDie += (object sender, EventArgs eventArgs) =>
        {
            OnPanel();
        };
    }

    void OnPanel()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
