using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombe : MonoBehaviour
{

    public Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col.enabled = false;
        StartCoroutine("Exploding");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Exploding()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("KILL ALL");
        col.enabled = true;
        Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy" || other.tag == "destructible")
        {
            Destroy(other.gameObject);
        }
    }
}
