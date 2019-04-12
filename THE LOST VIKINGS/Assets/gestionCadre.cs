using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gestionCadre : MonoBehaviour
{
    public IconManager _iconManager;
    public IconManager _iconManagerOlaf;
    public IconManager _iconManagerErik;
    public IconManager _iconManagerBaleog;

    public InventorySystem _inventorySystem;

    private int numero;

    public GameObject iconeSelected;

    public GameObject icone0;
    public GameObject icone1;
    public GameObject icone2;
    public GameObject icone3;

    private XboxController _xboxController;

    public GameObject olaf;
    public GameObject erik;
    public GameObject baleog;



    void Start()
    {

    }


    void Update()
    {

        //numero = _iconManager.iconeSelectNum;
        numero = Mathf.Clamp(_iconManager.iconeSelectNum, 0, 3);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (erik.GetComponent<XboxController>().thisIsSelected == true )
            {
                iconeSelected = GameObject.Find("InventoryErik/Panel/Slot1/Icon" + _iconManagerErik.iconeSelectNum);
            }

            if (olaf.GetComponent<XboxController>().thisIsSelected == true)
            {
                iconeSelected = GameObject.Find("InventoryOlaf/Panel/Slot1/Icon" + _iconManagerOlaf.iconeSelectNum);
            }

            if (baleog.GetComponent<XboxController>().thisIsSelected == true)
            {
                iconeSelected = GameObject.Find("InventoryBaleog/Panel/Slot1/Icon" + _iconManagerBaleog.iconeSelectNum);
            }

            this.transform.position = iconeSelected.transform.position;

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (erik.GetComponent<XboxController>().thisIsSelected == true)
            {
                iconeSelected = GameObject.Find("InventoryErik/Panel/Slot1/Icon" + _iconManagerErik.iconeSelectNum);
            }

            if (olaf.GetComponent<XboxController>().thisIsSelected == true)
            {
                iconeSelected = GameObject.Find("InventoryOlaf/Panel/Slot1/Icon" + _iconManagerOlaf.iconeSelectNum);
            }

            if (baleog.GetComponent<XboxController>().thisIsSelected == true)
            {
                iconeSelected = GameObject.Find("InventoryBaleog/Panel/Slot1/Icon" + _iconManagerBaleog.iconeSelectNum);
            }

            this.transform.position = iconeSelected.transform.position;
        }
    }
}