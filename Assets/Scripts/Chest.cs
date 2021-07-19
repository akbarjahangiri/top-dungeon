using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    [SerializeField] private Sprite emptyChest;
    [SerializeField] private int pesosAmount = 5;

    private void OnEnable()
    {
        
    }

    protected override void OnCollect()
    {
        if (!collected)
        {
            base.OnCollect();
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("grant: " + pesosAmount);
        }
    }

    public void PlayerDeathReward()
    {
        GetComponent<SpriteRenderer>().sprite = emptyChest;
        Debug.Log("You got the money!");
    }
}