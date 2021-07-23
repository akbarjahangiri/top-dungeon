using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using BirdTools;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

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
            GameManager.instance.ShowText("+" + goldAmount + "gold!", 30, Color.yellow, transform.position,
                Vector3.up * 100, 2f);
        }
    }

    public void PlayerDeathReward()
    {
        GetComponent<SpriteRenderer>().sprite = emptyChest;
        Debug.Log("You got the money!");
    }
}