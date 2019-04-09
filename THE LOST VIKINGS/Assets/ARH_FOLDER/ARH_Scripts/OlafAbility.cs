﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlafAbility : MonoBehaviour
{
    private bool shieldIsUp = false;
    Animator animShield;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 11, true);
        animShield = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (FindObjectOfType<XboxController>().index == 0)
        {
            /*if (animShield.GetCurrentAnimatorStateInfo(0).IsName("ShieldUpEnded") && Physics2D.GetIgnoreLayerCollision(8, 11) == true)
             {
                Debug.Log("Ignore collision false");
                Physics2D.IgnoreLayerCollision(8, 11, false);
            }*/

            animShield.SetBool("shieldIsUp", shieldIsUp);
            if (Input.GetKeyDown("joystick 1 button 2") && !shieldIsUp)
            {
                shieldIsUp = true;

                Physics2D.IgnoreLayerCollision(8, 11, false);
            }
            else if (Input.GetKeyDown("joystick 1 button 2") && shieldIsUp)
            {
                shieldIsUp = false;
                Debug.Log("Ignore collision true");
                Physics2D.IgnoreLayerCollision(8, 11);
            }

        }

    }
}
