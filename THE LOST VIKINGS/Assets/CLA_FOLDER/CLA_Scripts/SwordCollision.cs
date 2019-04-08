using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hi ?");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyBehavior enemy = collision.gameObject.GetComponent<EnemyBehavior>();
            enemy.LoseHP(1);
            Debug.Log("Hit an enemy");
        }
    }
}
