using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Climbing : MonoBehaviour
{
    Dictionary<Vikings, GameObject> myDico = new Dictionary<Vikings, GameObject>();

    // Start
    void Start()
    {
    }

    // Update
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Olaf")
        {
            myDico[Vikings.Olaf] = collision.gameObject;
            XboxController cc = myDico[Vikings.Olaf].GetComponent<XboxController>();
            cc.canClimb = true;
            Rigidbody2D rb = myDico[Vikings.Olaf].GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
        }
        else if (collision.tag == "Erik")
        {
            myDico[Vikings.Erik] = collision.gameObject;
            XboxController cc = myDico[Vikings.Erik].GetComponent<XboxController>();
            cc.canClimb = true;
            Rigidbody2D rb = myDico[Vikings.Erik].GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
        }
        else if (collision.tag == "Baleog")
        {
            myDico[Vikings.Baleog] = collision.gameObject;
            XboxController cc = myDico[Vikings.Baleog].GetComponent<XboxController>();
            cc.canClimb = true;
            Rigidbody2D rb = myDico[Vikings.Baleog].GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Olaf")
        {
            myDico[Vikings.Olaf] = collision.gameObject;
            XboxController cc = myDico[Vikings.Olaf].GetComponent<XboxController>();
            cc.canClimb = false;
            Rigidbody2D rb = myDico[Vikings.Olaf].GetComponent<Rigidbody2D>();
            rb.gravityScale = 1;
        }
        else if (collision.tag == "Erik")
        {
            myDico[Vikings.Erik] = collision.gameObject;
            XboxController cc = myDico[Vikings.Erik].GetComponent<XboxController>();
            cc.canClimb = false;
            Rigidbody2D rb = myDico[Vikings.Erik].GetComponent<Rigidbody2D>();
            rb.gravityScale = 1;
        }
        else if (collision.tag == "Baleog")
        {
            myDico[Vikings.Baleog] = collision.gameObject;
            XboxController cc = myDico[Vikings.Baleog].GetComponent<XboxController>();
            cc.canClimb = false;
            Rigidbody2D rb = myDico[Vikings.Baleog].GetComponent<Rigidbody2D>();
            rb.gravityScale = 1;
        }
    }
}

public enum Vikings {Olaf, Erik, Baleog}