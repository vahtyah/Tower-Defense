using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : UIGamePause
{
    private void Start()
    {
        Player.instance.OnPlayerDie += (object sender, EventArgs eventArgs) =>
        {
            print("Tuanpro");
            OnPanel();
        };
        gameObject.SetActive(false);
    }

    void OnPanel()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
