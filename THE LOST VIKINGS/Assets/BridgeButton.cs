using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    public BoxCollider2D toDisable;
    public BoxCollider2D toEnable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fleche")
        {
            toDisable.enabled = false;
            toEnable.enabled = true;
        }
    }

}
