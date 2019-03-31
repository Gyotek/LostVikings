using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyClass;

public class EnemyBehaviour : MonoBehaviour
{

    public Enemy enemyA;
    public GameObject clone;
    public Transform shootingTarget;
    public List<GameObject> cloneList = new List<GameObject>();

    public float lerpStep;
    public float dyingDelayValue = 5;

    void Start()
    {
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
}
