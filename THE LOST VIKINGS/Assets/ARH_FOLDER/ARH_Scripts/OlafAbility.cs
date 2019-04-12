using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlafAbility : MonoBehaviour
{
    public XboxController olafController;

    private bool shieldIsUp = false;
    public Rigidbody2D rb;

    public Sprite shieldUpSprite;
    public Sprite shieldDownSprite;

    public SpriteRenderer mySprite;

    public CapsuleCollider2D colRight;
    public CapsuleCollider2D colLeft;
    public CapsuleCollider2D colUp;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 11, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (olafController.thisIsSelected == true)
            Shield();

        if(olafController.isGrounded == false)
            Falling();

        if (olafController.thisIsSelected == true)
            Flip();
    }

    void Flip()
    {
        if (olafController.goingRight && mySprite.flipX)
        {
            mySprite.flipX = false;
            if (shieldIsUp == false && colRight.enabled == false)
            {
                colLeft.enabled = false;
                colRight.enabled = true;
            }
        }
        else if (!olafController.goingRight && !mySprite.flipX)
        {
            mySprite.flipX = true;
            if (shieldIsUp == false && colRight.enabled == true)
            {
                colLeft.enabled = true;
                colRight.enabled = false;
            }
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

        if (Input.GetKeyDown("joystick 1 button 2") && !shieldIsUp)
        {
            shieldIsUp = true;
            colUp.enabled = true;
            if (colRight.enabled == true)
                colRight.enabled = false;
            if (colLeft.enabled == true)
                colLeft.enabled = false;
            mySprite.sprite = shieldUpSprite;
            Physics2D.IgnoreLayerCollision(8, 11, false);
        }
        else if (Input.GetKeyDown("joystick 1 button 2") && shieldIsUp)
        {
            shieldIsUp = false;

            colUp.enabled = false;
            if(mySprite.flipX == true)
            {
                colRight.enabled = false;
                colLeft.enabled = true;
            }
            else if (mySprite.flipX == false)
            {
                colRight.enabled = true;
                colLeft.enabled = false;
            }

            mySprite.sprite = shieldDownSprite;
            Physics2D.IgnoreLayerCollision(8, 11);
        }
    }
}
