using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallBehavior : MonoBehaviour
{

    public XboxController erikController;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Erik") && erikController.speed >= 4 && erikController.isGrounded == true)
        {
            //Stun Erik
            Destroy(gameObject);
        }
    }
}
