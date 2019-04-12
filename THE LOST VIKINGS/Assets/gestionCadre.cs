using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionCadre : MonoBehaviour
{
    public IconManager _iconManager;
    public InventorySystem _inventorySystem;

    private int numero = 0;

    public GameObject iconeSelected;
    public string iconeName;
    public GameObject icone0;
    public GameObject icone1;
    public GameObject icone2;
    public GameObject icone3;



    void Start()
    {

    }


    void Update()
    {
        //iconeName = icone1;

        numero = Mathf.Clamp(numero, 0, 3);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            numero -= 1;
            iconeSelected = GameObject.Find("Icon" + numero);
            this.transform.position = iconeSelected.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            numero += 1;
            iconeSelected = GameObject.Find("Icon" + numero);
            this.transform.position = iconeSelected.transform.position;
        }
    }
}
