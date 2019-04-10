using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public bool myCollision;

    public GameObject objetInventaire;

    public int objectCounter = 0;

    void Start()
    {
        myCollision = false;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Object")
        {
            //inventaire.Add(other.gameObject);
            objetInventaire = other.gameObject;
            StartCoroutine(Coroutine());
            if (objectCounter < 4)
            {
                other.gameObject.SetActive(false);
                objectCounter += 1;
            }
        }
    }

    private IEnumerator Coroutine()
    {
        myCollision = true;
        yield return new WaitForEndOfFrame();
        myCollision = false;
    }
}