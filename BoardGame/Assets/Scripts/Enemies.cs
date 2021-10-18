using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int _enemyIndex = -1;

    string[] enemiesList = new string[]{"Low-Energy Lorax", "Shrek Wazowski",
    "Silver Streak", "justaBeaver", "Negative Kanye"};

    int[] damageList = new int[]{10, 15, 20, 15, 30};

    int[] healthList = new int[] {50, 50, 50, 50, 150};

    public SpriteRenderer spriteRenderer;
    public Sprite _enemyDefaultSprite;
    public Sprite _lowEnergyLorax;
    public Sprite _shrekWazowski;
    public Sprite _silverStreak;
    public Sprite _justaBeaver;
    public Sprite _negativeKanye;

    public void getEnemySprite()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _enemyDefaultSprite;

        if (_enemyIndex == 0)
        {
            spriteRenderer.sprite = _lowEnergyLorax;
        }

        else if (_enemyIndex == 1)
        {
            spriteRenderer.sprite = _shrekWazowski;
        }

        else if (_enemyIndex == 2)
        {
            spriteRenderer.sprite = _silverStreak;
        }

        else if (_enemyIndex == 3)
        {
            spriteRenderer.sprite = _justaBeaver;
        }

        else if (_enemyIndex == 4)
        {
            spriteRenderer.sprite = _negativeKanye;
        }

        else
        {
            spriteRenderer.sprite = _enemyDefaultSprite;
        }
    }

    public string getEnemyName()
    {
        string enemyName = enemiesList[_enemyIndex];

        return enemyName;
    }

    public int getEnemyDamage()
    {
        int enemyDamage = damageList[_enemyIndex];

        return enemyDamage;
    }

    public int getEnemyHealth()
    {
        int enemyHealth = healthList[_enemyIndex];

        return enemyHealth;
    }
}