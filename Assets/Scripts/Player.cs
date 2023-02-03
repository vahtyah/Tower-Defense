using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int Money;
    [SerializeField] int startMoney;

    private void Start()
    {
        Money = startMoney;
        print("Money's Player: " + Money);
    }

    public static void AddMoney(int money)
    {
        Money += money;
        print("Money's Player: " + Money);
    }

    public static void SubMoney(int money) {
        Money -= money;
        print("Money's Player: " + Money);
    }
}
