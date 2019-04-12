using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Olaf" || collision.tag == "Erik" || collision.tag == "Baleog")
        {
            XboxController xc = collision.gameObject.GetComponent<XboxController>();

            int temp = xc.hp;

            for(int i = 0; i<temp; i++)
            {
                xc.PlayerTakeDamages();
            }

        }
    }

}
