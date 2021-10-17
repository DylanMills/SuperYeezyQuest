using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int _abilityIndex = 0;

    string[] _abilitiesName = new string[] {"Fire Blade", "Smiting Hammer", "Bucket of Water", "Arrow Barrage"};
    int[] _abilitiesDamage = new int[] { 25, 35, 10, 40};

    public SpriteRenderer spriteRenderer;
    public Sprite abilityDefaultSprite;
    public Sprite fireBlade;
    public Sprite smitingHammer;
    public Sprite bucketWater;
    public Sprite arrowBarrage;

    public void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void getAbilitySprite()
    {
        if (_abilityIndex == 0)
        {
            spriteRenderer.sprite = fireBlade;
        }

        else if (_abilityIndex == 1)
        {
            spriteRenderer.sprite = smitingHammer;
        }

        else if (_abilityIndex == 2)
        {
            spriteRenderer.sprite = bucketWater;
        }

        else if (_abilityIndex == 3)
        {
            spriteRenderer.sprite = arrowBarrage;
        }

        else
        {
            spriteRenderer.sprite = abilityDefaultSprite;
            Debug.Log("Sprite Error");
        }
    }

    public string getAbilityName()
    {
        return _abilitiesName[_abilityIndex];
    }

    public int getAbilityDamage()
    {
        return _abilitiesDamage[_abilityIndex];
    }
}