using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public PathNode CurrentPathNode;
    public float movementSpeed = 5;
    Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CurrentPathNode)
        {
            transform.up = CurrentPathNode.transform.position - transform.position;
            body.velocity = transform.up * movementSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PathNode"))
        {

            PathNode node = collision.gameObject.GetComponent<PathNode>();
            if (node != null)
            {
                if (node == CurrentPathNode)
                    CurrentPathNode = node.NextNode;
            }
        }
    }
}
