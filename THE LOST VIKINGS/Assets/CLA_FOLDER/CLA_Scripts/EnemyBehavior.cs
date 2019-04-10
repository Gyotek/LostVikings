using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField]
    private int hp = 3;

    [SerializeField]
    private Rigidbody2D rigidBody;

    [SerializeField]
    private int thrust = 10;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void LoseHP (int hpToLose)
    {
        rigidBody.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        hp -= hpToLose;
    }
}
