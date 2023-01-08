using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int money;
    [SerializeField] float speed = 2;
    [SerializeField] float damage;

    //public Enemy(int health, int money, float speed,float damage)
    //{
    //    this.health = health;
    //    this.money = money;
    //    this.speed = speed;
    //    this.damage = damage;
    //}

    public int Health => health;
    public int Money => money;
    public float Speed => speed;
    public float Damage => damage;
}
