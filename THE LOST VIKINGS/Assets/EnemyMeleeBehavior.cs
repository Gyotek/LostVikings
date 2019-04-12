using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeBehavior : MonoBehaviour
{

    public float speed;

    [SerializeField]
    private float raycastDistance = 3.0f;

    private bool movingRight = true;

    public Transform groundDetection;

    public bool playerInRange = false;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, raycastDistance);
        if(groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }

            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        Debug.DrawRay(groundDetection.position, Vector2.down * raycastDistance);

        if (playerInRange == true)
        {
            Debug.Log("I see an enemy!");
        }
;    }
}
