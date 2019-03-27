using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField]
    private int hp = 3;

    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]
    private int thrust = 5;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
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
        rigidbody.AddForce(transform.up * thrust);
        hp -= hpToLose;
    }
}
