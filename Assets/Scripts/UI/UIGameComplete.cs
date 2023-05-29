using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameComplete : UIGamePause
{
    public void Init()
    {
        Player.instance.OnPlayerCompleteLevel += (object sender, EventArgs eventArgs) =>
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
