using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage Struct 
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // Upgrade detail
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer = new SpriteRenderer();

    // Swing 
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Fighter"))
        {
            if (coll.name == "Player")
                return;
            Debug.Log(coll.name);
            Damage dmg = gameObject.AddComponent<Damage>();
            dmg.damageAmount = damagePoint;
            dmg.origin = transform.position;
            dmg.pushForce = pushForce;

            coll.SendMessage("RecieveDamage", dmg);
        }
    }

    private void Swing()
    {
        Debug.Log("Swing");
    }
}