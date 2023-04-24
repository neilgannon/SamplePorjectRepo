using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBodyPart : MonoBehaviour
{
    public int Health = 100;
    public bool canBeDamaged = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && canBeDamaged)
        {
            if(Health <= 0)
            {
                gameObject.SetActive(false);
                canBeDamaged = false;
            }
        }
    }
}
