using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float boundX;
    [SerializeField] private float boundY;


    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        Vector3 delta = Vector3.zero;
        float deltaX = player.position.x - transform.position.x;

        // check if player is inside of bounds in X axis
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < player.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        float deltaY = player.position.y - transform.position.y;
        // check if player is inside of bounds in Y axis
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < player.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}