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
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (index == waypoints.Length)
        {
            goRight = false;
            index = waypoints.Length - 2;
            transform.eulerAngles = new Vector3(0, -180, 0);
        }

        if (playerInRange == true)
        {
            Debug.Log("I see an enemy!");
        }
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, agentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[index].position) < 0.1f) nextWaypoint();
    }
}
