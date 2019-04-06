using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyClass;
using Pathfinding;

public class EnemyBehaviour : MonoBehaviour
{

    public Enemy enemyA;
    public GameObject clone;
    public Transform shootingTarget;
    public List<GameObject> cloneList = new List<GameObject>();
    public List<Transform> waypoints = new List<Transform>();
    public int index = 0;

    private AIDestinationSetter positionTarget = null;

    public float lerpStep;
    public float projectiletDyingDelay = 5;

    void Start()
    {
        positionTarget = this.GetComponent<AIDestinationSetter>();
        positionTarget.target = waypoints[0];
        InvokeRepeating("ProjectileInstantiation", 0, enemyA.shootingRate);
    }

    private void Update()
    {
        DistanceAttack();

        if (enemyA.currentHp == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void ProjectileInstantiation()
    {
        clone = Instantiate(enemyA.projectile, this.transform);
        cloneList.Add(clone);
    }

    public void DistanceAttack()
    {
        foreach(GameObject go in cloneList)
        {
            go.transform.position = Vector3.Lerp(go.transform.position, shootingTarget.transform.position, lerpStep);
        }
    }

    public void MovingAttitude()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Waypoint" && collision.gameObject == waypoints[index].gameObject)
        {
            index++;

            if (index > waypoints.Count - 1)
            {
                index = 0;
            }

            positionTarget.target = waypoints[index];
        }
    }
}
