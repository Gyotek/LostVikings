using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollision : MonoBehaviour
{
    public EnemyMeleeBehavior selfViking;

    [SerializeField] float delayBeforeSlashing = 0.5f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Characters"))
        {
            Debug.Log("Entering Collision");
            selfViking.agentSpeed = 0;
            XboxController player = collision.GetComponent<XboxController>();
            StartCoroutine(DelayBeforeSlashing(player));

            selfViking.playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Characters"))
        {
            Debug.Log("Exiting Collision");
            selfViking.agentSpeed = 2.5f;
            StopAllCoroutines();

            selfViking.playerInRange = true;
        }
    }

    public IEnumerator DelayBeforeSlashing(XboxController player)
    {
        yield return new WaitForSeconds(delayBeforeSlashing);
        player.PlayerTakeDamages();
        StartCoroutine(DelayBeforeSlashing(player));
    }

}
