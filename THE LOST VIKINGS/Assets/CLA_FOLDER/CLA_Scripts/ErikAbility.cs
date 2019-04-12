using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErikAbility : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rigidBody;

    public XboxController controller;

    [SerializeField]
    private float thrust = 7;

    public bool isStunned = false;

    [SerializeField]
    private float stunDelay = 10.0f;

    public SpriteRenderer mySprite;

    public bool isRusing = false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.thisIsSelected == true && Input.GetKeyDown("joystick 1 button 2") || Input.GetKeyDown("return"))
        {
            if (controller.isGrounded == true && controller.canClimb == false)
            {
                rigidBody.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            }
        }

        //Rush
        if (controller.thisIsSelected == true && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            isRusing = true;
            if (controller.goingRight)
                this.gameObject.transform.rotation = Change(0, 0, -0.3f);
            else if (!controller.goingRight)
                this.gameObject.transform.rotation = Change(0, 0, 0.3f);
        }
        if (controller.thisIsSelected == true && Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            isRusing = false;
            this.gameObject.transform.rotation = Change(0, 0, 0);
        }


        if (isStunned == true)
        {
            StartCoroutine(erikStunDelay());
        }
        if (controller.thisIsSelected == true)
            Flip();
    }

    private static Quaternion Change(float x, float y, float z)
    {
        //Return the new Quaternion
        return new Quaternion(x, y, z, 1);
    }

    void Flip()
    {
        if (controller.goingRight && mySprite.flipX)
        {
            mySprite.flipX = false;


        }
        else if (!controller.goingRight && !mySprite.flipX)
        {
            mySprite.flipX = true;
        }
    }

    IEnumerator erikStunDelay()
    {
        rigidBody.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(stunDelay);
        isStunned = false;
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
        StopAllCoroutines();
    }
}
