using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : MonoBehaviour
{
    public Animation animPont;
    public CircleCollider2D Collider;

    private bool isPlayed = false;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Arrow" && isPlayed == false)
        {
            animPont.Play("Pont");
            isPlayed = true;
        }
    }
}
