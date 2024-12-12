using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line to include the UI namespace

public class Unit : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int currentHP;
    public int maxHP;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        return currentHP <= 0;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public bool IsAlive()
    {
        return currentHP > 0;
    }
}