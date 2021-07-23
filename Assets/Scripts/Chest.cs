using System;
using System.Collections;
using System.Collections.Generic;
using BirdTools;
using UnityEngine;

public class Chest : Collectable
{
    [SerializeField] private Sprite emptyChest;
    [SerializeField] private int goldAmount = 5;
    public IntVariable gold;

    private void OnEnable()
    {
        
    }

    protected override void OnCollect()
    {
        if (!collected)
        {
            base.OnCollect();
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            gold.Value += goldAmount;
            Debug.Log("grant: " + goldAmount);
        }
    }

    public void PlayerDeathReward()
    {
        GetComponent<SpriteRenderer>().sprite = emptyChest;
        Debug.Log("You got the money!");
    }
}