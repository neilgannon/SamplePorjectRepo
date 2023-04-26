using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossFightState
{
    AttackingArms,
    AttackingBody,
    AttackingHead
}

public class Boss : MonoBehaviour
{
    [Header("Boss Moves")]
    public AnimationClip[] possibleBossMoves;
    int currentMove = 0;
    public float timeBetweenMoves = 5;
    public Animator animator;
    string defaultState = "Default";
    bool hasJustMadeMove = false;

    void Start()
    {
        InvokeRepeating("PickNextMove", timeBetweenMoves, timeBetweenMoves);
    }

    void PickNextMove()
    {
        if (!hasJustMadeMove)
        {
            if (currentMove >= possibleBossMoves.Length)
                currentMove = 0;

            animator.Play(possibleBossMoves[currentMove].name);
            currentMove++;

            hasJustMadeMove = true;

            UpdateBoss();
        }
        else
        {
            animator.Play(defaultState);
            hasJustMadeMove = false;
        }
    }

    public void UpdateBoss()
    {
        if (currentMove < possibleBossMoves.Length)
        {
            string moveName = possibleBossMoves[currentMove].name;

            if (moveName == "ArmSwing")
            {

            }
            else if (moveName == "ArmSlam")
            {

            }
            else if (moveName == "BodySlam")
            {

            }
        }
    }

    private void Update()
    {

    }
}