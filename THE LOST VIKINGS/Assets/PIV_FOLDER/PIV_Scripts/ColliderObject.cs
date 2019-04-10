using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderObject : MonoBehaviour
{
    public List<GameObject> inventaire = new List<GameObject>();

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collision Player " + this.gameObject.name);
            inventaire.Add (this.gameObject);
        }
    }

}