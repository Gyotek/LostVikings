using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 7;

    public int damage = 1;

    [SerializeField]
    private float destroyCoolDown = 3f;

    public Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(transform.right * speed, ForceMode2D.Force);
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Invisible");
        StartCoroutine(DestroyDelay());
    }

    private void OnBecameVisible()
    {
        Debug.Log("Visible");
        StopCoroutine(DestroyDelay());
    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(destroyCoolDown);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(this + " hit an enemy");
            EnemyBehavior enemy = collision.gameObject.GetComponent<EnemyBehavior>();
            enemy.LoseHP(damage);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Button")
        {
            Debug.Log(this + " hit a button");
            //ButtonBehavior button = collision.gameObject.GetComponent<ButtonBehavior>();
            //button.triggerButton();
            //Destroy(gameObject);
        }

        else if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
