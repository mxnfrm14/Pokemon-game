using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitEnnemy : MonoBehaviour
{
    public string unitNameE;
    public int damageE;
    public int currentHPE;
    public int maxHPE;

    public bool TakeDamage(int dmg)
    {
        currentHPE -= dmg;
        return currentHPE <= 0;
    }

    public void Heal(int amount)
    {
        currentHPE += amount;
        if (currentHPE > maxHPE)
        {
            currentHPE = maxHPE;
        }
    }

    public bool IsAlive()
    {
        return currentHPE > 0;
    }
}