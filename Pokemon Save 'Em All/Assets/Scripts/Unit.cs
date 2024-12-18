using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int currentHP;
    public int maxHP;

    void Start()
    {
        // Initialize currentHP with playerHealth's health
        if (playerHealth.Instance != null)
        {
            currentHP = (int)playerHealth.Instance.health;
            maxHP = (int)playerHealth.Instance.maxHealth;
        }
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (playerHealth.Instance != null)
        {
            playerHealth.Instance.UpdateHealth(currentHP);
        }
        return currentHP <= 0;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        if (playerHealth.Instance != null)
        {
            playerHealth.Instance.UpdateHealth(currentHP);
        }
    }

    public bool IsAlive()
    {
        return currentHP > 0;
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }
}