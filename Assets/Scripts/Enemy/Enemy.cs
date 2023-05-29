using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static GameObject Create(GameObject EnemyPrefab, int health)
    {
        var enemy = ObjectPooler.instance.ActivateObject(EnemyPrefab.tag);
        enemy.GetComponent<Enemy>().health = health;
        enemy.SetActive(true);
        return enemy;
    }

    public static void Destroy(GameObject EnemyPrefab)
    {
        Enemy enemy = EnemyPrefab.GetComponent<Enemy>();
        if(enemy != null)
            Player.Instance.ChangeMoney(enemy.Money);
        ObjectPooler.instance.DeactivateObject(EnemyPrefab);
    }

    [SerializeField] int health = 100;
    [SerializeField] int money = 10;
    [SerializeField] float speed = 2;
    [SerializeField] float damage;
    [SerializeField] AudioClip destructionSound;
    public Image healthBar;

    HealthSystem healthSystem;

    private void Start()
    {
        print(health);
        healthSystem = new HealthSystem(health);
        healthSystem.OnHealthChanged += (object sender, EventArgs eventArgs) =>
        {
            healthBar.fillAmount = healthSystem.GetHealthPrecent();
        };
    }

    public void SetHealth(int amount)
    {
        health = amount;
    }

    public void Damage(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
        if (IsDead())
        {
            Player.instance.ChangeMoney(money);
            Enemy.Destroy(gameObject);
            AudioSource.PlayClipAtPoint(destructionSound, transform.position);
            healthSystem.ResetHealth();
        }
    }

    public bool IsDead()
    {
        return healthSystem.IsDead();
    }
    
    public int Money => money;
    public float Speed => speed;
}
