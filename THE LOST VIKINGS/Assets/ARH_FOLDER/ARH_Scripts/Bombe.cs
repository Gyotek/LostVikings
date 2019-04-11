using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombe : MonoBehaviour
{
    private bool explode = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Exploding");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Exploding()
    {
        yield return new WaitForSeconds(5f);
        explode = true;
        Debug.Log("KILL ALL");
        Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (explode = true && other.tag == "enemy" || other.tag == "destructible")
        {
            Destroy(other.gameObject);
        }
    }
}
