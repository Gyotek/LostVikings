using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
    [SerializeField]
    private bool canHit = true;

    [SerializeField]
    private float swordCoolDown = 3.0f;

    [SerializeField]
    private int damage = 1;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colliding with :", collision.gameObject);
        if (collision.gameObject.tag == "Enemy") //&& FindObjectOfType<XboxController>().index == 2 && canHit == true)
        {
            Debug.Log("Collision with Enemy : OK!");
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                Debug.Log("Pressed BackSpace : OK!");
                if (FindObjectOfType<XboxController>().index == 2)
                {
                    Debug.Log("Baleog is Selected: OK!");
                    if (canHit)
                    {
                        Debug.Log("CoolDown to hit is reset : OK!");
                        canHit = false;
                        StartCoroutine(SwordCoolDown());
                        EnemyBehavior enemy = collision.gameObject.GetComponent<EnemyBehavior>();
                        enemy.LoseHP(damage);
                    }
                }
            }
        }
        
    }

    private IEnumerator SwordCoolDown()
    {
        yield return new WaitForSeconds(swordCoolDown);
        canHit = true;
    }
}
