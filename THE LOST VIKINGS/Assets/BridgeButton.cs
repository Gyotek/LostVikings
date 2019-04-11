using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    public GameObject toDisable;
    public GameObject toEnable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fleche")
        {
            toDisable.SetActive(false);
            toEnable.SetActive(true);

            Destroy(collision.gameObject);
        }
    }

}
