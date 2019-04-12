using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollision : MonoBehaviour
{

    public EnemyMeleeBehavior selfViking;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Characters"))
        {
            Debug.Log("Entering Collision");
            selfViking.playerInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Characters"))
        {
            Debug.Log("Exiting Collision");
            selfViking.playerInRange = true;
        }
    }

}
