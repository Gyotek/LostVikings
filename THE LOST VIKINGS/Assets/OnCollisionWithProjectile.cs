using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionWithProjectile : MonoBehaviour
{
    public EnemyBehaviour myShooter;

    void Start()
    {
        StartCoroutine("DyingDelay");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Erik" || collision.tag == "Baleog" || collision.tag == "Olaf")
        {
            XboxController player = collision.GetComponent<XboxController>();
            for(int i = 0; i < myShooter.enemyA.damages; i++)
            {
                player.PlayerTakeDamages();
            }

            Destroying();
        }
        else if(collision.tag == "Shield")
        {
            Destroying();
        }
    }

    IEnumerator DyingDelay()
    {
        yield return new WaitForSeconds(myShooter.projectiletDyingDelay);

        if(this.gameObject.name != "Projectile")
        {
            Destroying();
        }

    }

    private void Destroying()
    {
        GameObject tmp = myShooter.cloneList[myShooter.cloneList.IndexOf(this.gameObject)];
        myShooter.cloneList.Remove(tmp);
        Destroy(tmp);
    }

}
