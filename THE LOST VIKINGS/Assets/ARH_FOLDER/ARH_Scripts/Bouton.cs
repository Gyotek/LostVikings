using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : MonoBehaviour
{
    public Animation animPont;
    public CircleCollider2D Collider;

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collider2D other)
    {
        Debug.Log("test");
        if (other.tag == "Arrow")
        {
            animPont.Play("Pont");
            Destroy(other.gameObject);
        }
    }
}
