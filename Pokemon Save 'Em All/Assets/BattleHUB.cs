using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TMP_Text nameText;
    public Slider hpSlider;

    // For Unit
    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    // For UnitEnnemy
    public void SetHUD2(UnitEnnemy enemy)
    {
        nameText.text = enemy.unitNameE;
        hpSlider.maxValue = enemy.maxHPE;
        hpSlider.value = enemy.currentHPE;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
