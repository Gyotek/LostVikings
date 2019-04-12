using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlafAbility : MonoBehaviour
{
    public XboxController olafController;

    private bool shieldIsUp = false;
    Animator animShield;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 11, true);
        animShield = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Shield();

        if(olafController.isGrounded == false)
        {
            Falling();
        }
    }

    void Falling()
    {
        if (shieldIsUp == true && rb.gravityScale != 0.4f)
        {
            rb.gravityScale = 0.4f;
        }
        else if (shieldIsUp == false && rb.gravityScale != 1f)
        {
            rb.gravityScale = 1f;
        }
    }

    void Shield()
    {
        if (olafController.thisIsSelected == true)
        {
            /*if (animShield.GetCurrentAnimatorStateInfo(0).IsName("ShieldUpEnded") && Physics2D.GetIgnoreLayerCollision(8, 11) == true)
             {
                Debug.Log("Ignore collision false");
                Physics2D.IgnoreLayerCollision(8, 11, false);
            }*/

            animShield.SetBool("shieldIsUp", shieldIsUp);
            if ((Input.GetKeyDown("joystick 1 button 2") || Input.GetKeyDown("return")) && !shieldIsUp)
            {
                shieldIsUp = true;

                Physics2D.IgnoreLayerCollision(8, 11, false);
            }
            else if (Input.GetKeyDown("joystick 1 button 2") || Input.GetKeyDown("return") && shieldIsUp)
            {
                shieldIsUp = false;
                Physics2D.IgnoreLayerCollision(8, 11);
            }

        }
    }
}
