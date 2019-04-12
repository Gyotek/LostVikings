using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyMeleeBehavior enemy = collision.gameObject.GetComponent<EnemyMeleeBehavior>();
            enemy.LoseHP(1);
        }
    }
}
