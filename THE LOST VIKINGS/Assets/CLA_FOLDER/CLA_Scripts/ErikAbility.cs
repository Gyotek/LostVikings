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
    private float stunDelay = 1.0f;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.thisIsSelected == true && Input.GetKeyDown("joystick 1 button 2"))
        {
            if (controller.isGrounded == true && controller.canClimb == false)
            {
                rigidBody.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            }
        }

        if (isStunned == true)
        {
            StartCoroutine(erikStunDelay());
        }
    }

    IEnumerator erikStunDelay()
    {
        yield return new WaitForSeconds(stunDelay);
        isStunned = false;
    }
}
