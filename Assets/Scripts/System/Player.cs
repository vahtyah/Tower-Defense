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
        OnChangeMoney?.Invoke(this, EventArgs.Empty);
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
        if (lives < 0) return;
        OnChangeLives?.Invoke(this, EventArgs.Empty);
        lives--;
    }

    public bool IsLive() => lives > 0;
}
