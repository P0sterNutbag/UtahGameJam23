using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int dictator;
    public int resistance;

    private void Start()
    {
        dictator = 50;
        resistance = 50;
    }

    public void ChangeDictator(int score)
    {
        dictator += score;
    }

    public void ChangeResistance(int score)
    {
        resistance += score;
    }




}
