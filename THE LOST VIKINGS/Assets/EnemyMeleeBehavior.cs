using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeBehavior : MonoBehaviour
{
    public bool playerInRange = false;

    [SerializeField] Transform[] waypoints;
    [SerializeField] int index;
    [SerializeField] bool goRight =true;
    public float agentSpeed;
    [SerializeField] bool active;

    public int hp = 3;

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

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, agentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[index].position) < 0.1f) nextWaypoint();
    }

    public void LoseHP(int damage)
    {
        hp -= damage;
    }
}
