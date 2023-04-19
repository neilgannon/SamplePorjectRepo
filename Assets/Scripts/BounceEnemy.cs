using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEnemy : MonoBehaviour
{
    public Vector2 Direction;
    public float MovementSpeed = 1;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.velocity = Direction * MovementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Direction *= -1;
        }
    }
}
