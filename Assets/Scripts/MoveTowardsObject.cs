using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour
{
    Transform objectToFollow;
    Rigidbody2D body;
    public float movementSpeed = 3;

    void Start()
    {
        objectToFollow = GameObject.FindGameObjectWithTag("Player").transform;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.up = objectToFollow.position - transform.position;
        body.velocity = transform.up * movementSpeed;
    }
}
