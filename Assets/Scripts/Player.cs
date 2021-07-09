using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    private Vector3 _moveDelta;

    // Horizontal and Vertical inputs
    private float _x;
    private float _y;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        _x = Input.GetAxisRaw("Horizontal");
        _y = Input.GetAxisRaw("Vertical");

        // Reset MoveDelta
        _moveDelta = new Vector3(_x, _y, 0);

        // Swipe the sprite direction, when you are going right or left
        // Horizontal move Controls
        if (_moveDelta.x > 0)
        {
            var hit = Physics2D.BoxCast(transform.position, _boxCollider2D.size, 0, new Vector2(_moveDelta.x, 0),
                Mathf.Abs(_moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
                transform.Translate(_moveDelta * Time.deltaTime);
            }

            transform.localScale = Vector3.one;
        }
        else if (_moveDelta.x < 0)
        {
            var hit = Physics2D.BoxCast(transform.position, _boxCollider2D.size, 0, new Vector2(_moveDelta.x, 0),
                Mathf.Abs(_moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
                transform.Translate(_moveDelta * Time.deltaTime);
            }

            transform.localScale = new Vector3(-1, 1, 0);
        }
        // Vertical move Controls
        else if (_moveDelta.y > 0)
        {
            var hit = Physics2D.BoxCast(transform.position, _boxCollider2D.size, 0, new Vector2(0, _moveDelta.y),
                Mathf.Abs(_moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
                transform.Translate(_moveDelta * Time.deltaTime);
            }
        }
        else if (_moveDelta.y < 0)
        {
            var hit = Physics2D.BoxCast(transform.position, _boxCollider2D.size, 0, new Vector2(0, _moveDelta.y),
                Mathf.Abs(_moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
                transform.Translate(_moveDelta * Time.deltaTime);
            }
        }
    }
}