using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlafAbility : MonoBehaviour
{
    private bool shieldIsUp = false;
    Animator animShield;

    // Start is called before the first frame update
    void Start()
    {
        animShield = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animShield.GetCurrentAnimatorStateInfo(0).IsName("ShieldUpEnded") && Physics2D.GetIgnoreLayerCollision(8, 10) == true)
        {
            Debug.Log(animShield.GetCurrentAnimatorStateInfo(0));
            Physics2D.IgnoreLayerCollision(8, 10, false);
        }

        animShield.SetBool("shieldIsUp", shieldIsUp);
        if (Input.GetKeyDown("joystick 1 button 2") && !shieldIsUp)
        {
            shieldIsUp = true;
        }
        else if (Input.GetKeyDown("joystick 1 button 2") && shieldIsUp)
        {
            shieldIsUp = false;
            Physics2D.IgnoreLayerCollision(8, 10, true);
        }
    }
}
