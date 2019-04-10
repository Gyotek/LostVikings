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

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<XboxController>().index == 1 && Input.GetKeyDown("return"))
        {
            if (controller.isGrounded == true && controller.canClimb == false)
            {
                rigidBody.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            }
        }
    }
}
