using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static GameObject Create(GameObject EnemyPrefab)
    {
        var enemy = ObjectPooler.instance.ActivateObject(EnemyPrefab.tag);
        enemy.SetActive(true);
        return enemy;
    }

    public static void Destroy(GameObject EnemyPrefab)
    {
        ObjectPooler.instance.DeactivateObject(EnemyPrefab);
    }

    [SerializeField] int health = 100;
    [SerializeField] int money;
    [SerializeField] float speed = 2;
    [SerializeField] float damage;
    [SerializeField] AudioClip destructionSound;
    public Image healthBar;

    HealthSystem healthSystem;

    private void Start()
    {
        healthSystem = new HealthSystem(health);
        healthSystem.OnHealthChanged += (object sender, EventArgs eventArgs) =>
        {
            healthBar.fillAmount = healthSystem.GetHealthPrecent();
        };
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
