using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> inventaire = new List<GameObject>();

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
            Debug.Log("Collision Object ");
            //inventaire.Add(other.gameObject);
            objetInventaire = other.gameObject;
            StartCoroutine(Coroutine());
            if (objectCounter < 4)
            {
                other.gameObject.SetActive(false);
                objectCounter += 1;
                Debug.Log("objectCounter = " + objectCounter);
            }
        }
    }

    private IEnumerator Coroutine()
    {
        myCollision = true;
        Debug.Log("coroutine played");
        yield return new WaitForEndOfFrame();
        myCollision = false;
    }
}