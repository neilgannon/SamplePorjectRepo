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

    //Player must destroy parts in the order of Arms -> Body -> Head
    [Header("Body Parts")]
    public BossBodyPart Head;
    public BossBodyPart Body;
    public BossBodyPart LeftArm;
    public BossBodyPart RightArm;
    public BossFightState CurrentBodyState;

    void Start()
    {
        InvokeRepeating("PickRandomMove", timeBetweenMoves, timeBetweenMoves);
    }

    void PickRandomMove()
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
        string moveName = possibleBossMoves[currentMove].name;

        if(moveName == "ArmSwing")
        {

        }
        else if(moveName == "ArmSlam")
        {

        }
        else if(moveName == "BodySlam")
        {

        }
    }

    private void Update()
    {
        switch (CurrentBodyState)
        {
            case BossFightState.AttackingArms:
                LeftArm.canBeDamaged = true;
                RightArm.canBeDamaged = true;
                break;

            case BossFightState.AttackingBody:
                Body.canBeDamaged = true;
                break;

            case BossFightState.AttackingHead:
                Head.canBeDamaged = true;
                break;
        }
    }
}
