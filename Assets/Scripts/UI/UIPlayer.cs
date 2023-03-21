using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cost;
    Player player;
    private void Start()
    {
        player = Player.instance;
        SetCostText();
        player.OnChangeMoney += (object sender, EventArgs eventArgs) =>
        {
            SetCostText();
        };
    }

    void SetCostText()
    {
        cost.text = "$" + player.GetMoney().ToString();
    }
}
