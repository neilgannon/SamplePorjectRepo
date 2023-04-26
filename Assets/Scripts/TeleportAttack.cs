using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeleportEnemyState
{
    Idle,
    Following,
    Attacking
}

public class TeleportAttack : MonoBehaviour
{
    public float timeToWaitBeforeFollowing = 5;
    public float timeToWaitBeforeAttack = 2;
    public float timeToStayAttacking = 0.25f;

    public float movementSpeed = 5;
    public float attackSpeed = 10;

    Rigidbody2D body;
    public TeleportEnemyState State;
    Transform player;
    Transform pointAbovePlayer;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pointAbovePlayer = player.GetChild(0);
    }

    void Update()
    {
        if(State == TeleportEnemyState.Idle)
        {
            body.velocity = Vector2.zero;
             
            if (!IsInvoking("StartFollowing"))
                Invoke("StartFollowing", timeToWaitBeforeFollowing);
        }
        else if(State == TeleportEnemyState.Following)
        {
            body.velocity = (pointAbovePlayer.position - transform.position) * movementSpeed;

            if (Vector2.Distance(transform.position, pointAbovePlayer.position) <= 2)
            {
                if (!IsInvoking("StartAttacking"))
                    Invoke("StartAttacking", timeToWaitBeforeAttack);
            }
        }
        else if(State == TeleportEnemyState.Attacking)
        {
            body.velocity = (player.position - transform.position).normalized * attackSpeed;

            if (!IsInvoking("StartIdling"))
                Invoke("StartIdling", timeToStayAttacking);
        }
    }

    void StartIdling()
    {
        State = TeleportEnemyState.Idle;
    }

    void StartFollowing()
    {
        State = TeleportEnemyState.Following;
    }

    void StartAttacking()
    {
        State = TeleportEnemyState.Attacking;
    }
}
