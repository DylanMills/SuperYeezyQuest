using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int RollDice()
    {
        float diceRoll = Random.Range(1, 7);
        return (int)diceRoll;
    }
}
