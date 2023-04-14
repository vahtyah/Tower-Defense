using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public static Player instance
    {
        get
        {
            if (Instance == null)
                Instance = FindObjectOfType<Player>();
            return Instance;
        }
    }
    public event EventHandler OnChangeMoney;
    public event EventHandler OnChangeLives;
    public event EventHandler OnPlayerDie;

    public int Money;
    [SerializeField] int startMoney;
    [SerializeField] int lives = 3;

    private void Awake()
    {
        Money = startMoney;
        print("Money's Player: " + Money);
    }

    public void ChangeMoney(int money)
    {
        Money += money;
        OnChangeMoney?.Invoke(Money, EventArgs.Empty);
        print("Money's Player: " + Money);
    }

    public int GetMoney()
    {
        return Money;
    }

    public int GetLives()
    {
        return lives;
    }

    public void DeIncreaseLives()
    {
        if (lives <= 0)
        {
            OnPlayerDie?.Invoke(this, EventArgs.Empty);
            return;
        }
        lives--;
        OnChangeLives?.Invoke(lives, EventArgs.Empty);
        print("Lives's Player: " + lives);
    }
}
