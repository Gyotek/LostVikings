using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARH_Bouton : MonoBehaviour
{
    public Animation animPont;

    // Start is called before the first frame update
    void Start()
    {
        animPont.Play("Pont");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
