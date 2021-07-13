using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    [SerializeField] private Sprite emptyChest;
    [SerializeField] private int pesosAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            base.OnCollect();
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("grant: " + pesosAmount);
        }
    }
}