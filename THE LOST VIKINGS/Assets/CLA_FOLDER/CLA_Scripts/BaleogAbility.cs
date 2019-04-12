using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaleogAbility : MonoBehaviour
{
    public XboxController baleogController;

    [SerializeField]
    private Vector3 thisPosition;

    [SerializeField]
    private GameObject arrow;

    [SerializeField]
    private float arrowCoolDown = 1.5f;

    [SerializeField]
    private bool canShoot = true;

    [SerializeField]
    private bool canHit = true;

    [SerializeField]
    private float swordCoolDown = 1.0f;

    [SerializeField]
    private int swordDamage = 1;

    public Collider2D swordCollision;

    private void Awake()
    {
        swordCollision.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        thisPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if ((Input.GetKeyDown("return") || Input.GetKeyDown(KeyCode.Joystick1Button0)) && baleogController.thisIsSelected == true && canShoot == true)
        {
            Instantiate(arrow, thisPosition, Quaternion.identity);
            canShoot = false;
            StartCoroutine(ArrowCoolDown());
        }

        if ((Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown("backspace")) && canHit && baleogController.thisIsSelected == true)
        {
            canHit = false;
            StartCoroutine(SwordCoolDown());
            swordCollision.enabled = true;
            Debug.Log("Slash!");
        }
    }

    private IEnumerator ArrowCoolDown()
    {
        yield return new WaitForSeconds(arrowCoolDown);
        canShoot = true;
    }

    private IEnumerator SwordCoolDown()
    {
        yield return new WaitForSeconds(swordCoolDown);
        swordCollision.enabled = false;
        canHit = true;
    }
}
