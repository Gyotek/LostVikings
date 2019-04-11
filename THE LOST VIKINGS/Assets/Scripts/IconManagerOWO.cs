using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManagerOWO : MonoBehaviour
{
    public Image[] icones;

    public Sprite icon;
    Image myImage;
    private SpriteRenderer theRenderer;

    private string iconName;

    private int num;

    public InventorySystem _InventorySystem;

    public Sprite blank;
    public Image imageBlank;

    private int iconeSelectNum;

    private string iconeSelectName;


    void Start()
    {
        num = 0;
        iconName = "Icon"+num;
        blank = imageBlank.sprite;
        iconeSelectNum = 0;
    }

    public void Update()
    {

        iconeSelectNum = Mathf.Clamp(iconeSelectNum, 0, 3);
        //Debug.Log("iconeSelectNum = " + iconeSelectNum);

        if (_InventorySystem.myCollision == true)
        {
            iconName = "Icon" + num;
            GetSpriteFrom();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            imageBlank = icones[iconeSelectNum];
            imageBlank.sprite = blank;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            iconeSelectNum -= 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            iconeSelectNum += 1;
        }
    }

    public void GetSpriteFrom()
    {
        myImage = this.transform.Find(iconName).GetComponent<Image>();
        theRenderer = _InventorySystem.objetInventaire.GetComponent<SpriteRenderer>();
        icon = theRenderer.sprite;
        myImage.sprite = icon;
        icones[num] = myImage;
        num = num + 1;

        /*foreach (GameObject objet in myInventory.inventaire)
        {
            myImage = this.transform.Find(iconName).GetComponent<Image>();
            theRenderer = objet.GetComponent<SpriteRenderer>();
            icon = theRenderer.sprite;
            myImage.sprite = icon;
            icones[num] = myImage;
            num = num+1;
            Debug.Log(num);
        }*/
    }
}