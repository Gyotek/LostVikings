using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaleogAbility : MonoBehaviour
{
    [SerializeField]
    private Vector3 thisPosition;

    [SerializeField]
    private GameObject arrow;

    [SerializeField]
    private float arrowCoolDown = 1.5f;

    [SerializeField]
    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        thisPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Input.GetKeyDown("return") && FindObjectOfType<XboxController>().index == 2 && canShoot == true)
        {
            Instantiate(arrow, thisPosition, Quaternion.identity);
            canShoot = false;
            StartCoroutine(ArrowCoolDown());
        }
    }

    private IEnumerator ArrowCoolDown()
    {
        yield return new WaitForSeconds(arrowCoolDown);
        canShoot = true;
    }
}
