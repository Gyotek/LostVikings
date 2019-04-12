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

    public GameObject olaf;
    public GameObject erik;
    public GameObject baleog;

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

    public void Bomb()
    {
        if (FindObjectOfType<XboxController>().index == 0)
        {
            Instantiate(bombPrefab, olaf.transform.position, olaf.transform.rotation);
        }
        else if (FindObjectOfType<XboxController>().index == 1)
        {
            Instantiate(bombPrefab, erik.transform.position, erik.transform.rotation);
        }
        else if (FindObjectOfType<XboxController>().index == 2)
        {
            Instantiate(bombPrefab, baleog.transform.position, baleog.transform.rotation);
        }
    }

    public void Battery()
    {
        if(FindObjectOfType<XboxController>().index == 0)
        {
            //Redonne une life a Olaf
        }
        else if (FindObjectOfType<XboxController>().index == 1)
        {
            //Redonne une life a Erik
        }
        else if (FindObjectOfType<XboxController>().index == 2)
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
        if (isNuking == true || other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }

}
