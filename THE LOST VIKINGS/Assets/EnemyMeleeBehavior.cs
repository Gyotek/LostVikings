using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeBehavior : MonoBehaviour
{
    public bool playerInRange = false;

    [SerializeField] Transform[] waypoints;
    [SerializeField] int index;
    [SerializeField] bool goRight =true;
    [SerializeField] float agentSpeed;
    [SerializeField] bool active;


    // Update is called once per frame
    /*void Update()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);

        rigidBody.velocity = Vector2.right * speed;

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
    } */

    private void Update()
    {
        if (active) Movement();
    }

    void nextWaypoint()
    {
        if (goRight) index++;
        else index--;

        if(index == -1)
        {
            goRight = true;
            index = 1;
        }
        else if (index == waypoints.Length)
        {
            goRight = false;
            index = waypoints.Length - 2;
        }
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, agentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[index].position) < 0.1f) nextWaypoint();
    }
}
