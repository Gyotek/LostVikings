using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallBehavior : MonoBehaviour
{

    public XboxController erikController;
    public ErikAbility erikAbility;
    public Rigidbody2D erikBody;

    [SerializeField]
    private float stunForce = 3.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Erik") && erikController.speed >= 0.5f/* && erikController.isGrounded == true*/ && erikAbility.isRusing == true)
        {
            StunErik();
            Destroy(gameObject);
        }
    }

    public void StunErik()
    {
        erikBody.AddForce(transform.up * stunForce, ForceMode2D.Impulse);
        erikAbility.isStunned = true;
    }
}
