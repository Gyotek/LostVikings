using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hi ?");
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyBehavior enemy = collision.gameObject.GetComponent<EnemyBehavior>();
            enemy.LoseHP(1);
            Debug.Log("Hit an enemy");
        }
    }
}
