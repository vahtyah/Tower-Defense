using System;
using UnityEngine.EventSystems;

public class HealthSystem
{
    public event EventHandler OnHealthChanged;
    public event EventHandler OnDamage;
    public event EventHandler OnDead;


    int healthMax;
    int health;

    public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public void ResetHealth() { health = healthMax;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
    public int GetHealth() { return health; }
    public int GetHealthMax() { return healthMax; }
    public float GetHealthPrecent() { return (float)health / healthMax; }
    public void Damage(int amountDamage)
    {
        health -= amountDamage;
        if (health < 0)
        {
            health = 0;
            Die();
        }
        OnHealthChanged?.Invoke(this,EventArgs.Empty);
        OnDamage?.Invoke(this,EventArgs.Empty);
    }   

    public void Die()
    {
        OnDead?.Invoke(this, EventArgs.Empty);
    }

    public bool IsDead()
    {
        return health <= 0;
    }
    
}
