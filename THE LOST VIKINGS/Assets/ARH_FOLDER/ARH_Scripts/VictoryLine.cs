using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryLine : MonoBehaviour
{

    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(count);

        if (count == 3)
            SceneManager.LoadScene("ARH_Winning");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Olaf" || other.gameObject.tag == "Erik" || other.gameObject.tag == "Baleog")
        {
            count++;
        }
    }
}
