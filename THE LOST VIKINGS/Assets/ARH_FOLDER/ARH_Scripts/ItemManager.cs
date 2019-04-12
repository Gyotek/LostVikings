using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [INDEX VALUES]
//   0 = Olaf
//   1 = Erik
//   2 = Baleog

public class ItemManager : MonoBehaviour
{

    public Collider2D nukeCollider;
    private bool isNuking = false;

    public GameObject bombPrefab;
    public GameObject keyPrefab;

    public GameObject olaf;
    public GameObject erik;
    public GameObject baleog;

    public XboxController olafController;
    public XboxController erikController;
    public XboxController baleogController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Nuke()
    {
        StartCoroutine("Nuking");
    }

    public void Key()
    {
        if (olafController.thisIsSelected == true)
        {
            Instantiate(keyPrefab, olaf.transform.position, olaf.transform.rotation);
        }
        else if (erikController.thisIsSelected == true)
        {
            Instantiate(keyPrefab, erik.transform.position, erik.transform.rotation);
        }
        else if (baleogController.thisIsSelected == true)
        {
            Instantiate(keyPrefab, baleog.transform.position, baleog.transform.rotation);
        }
    }

    public void Bomb()
    {
        if (olafController.thisIsSelected == true)
        {
            Instantiate(bombPrefab, olaf.transform.position, olaf.transform.rotation);
        }
        else if (erikController.thisIsSelected == true)
        {
            Instantiate(bombPrefab, erik.transform.position, erik.transform.rotation);
        }
        else if (baleogController.thisIsSelected == true)
        {
            Instantiate(bombPrefab, baleog.transform.position, baleog.transform.rotation);
        }
    }

    public void Battery()
    {
        if(olafController.thisIsSelected == true)
        {
            //Redonne une life a Olaf
        }
        else if (erikController.thisIsSelected == true)
        {
            //Redonne une life a Erik
        }
        else if (baleogController.thisIsSelected == true)
        {
            //Redonne une life a Olaf
        }

    }

    IEnumerator Nuking()
    {
        isNuking = true;
        nukeCollider.enabled = true;
        yield return new WaitForSeconds(0.1f);
        isNuking = false;
        nukeCollider.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isNuking == true && other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }

}
