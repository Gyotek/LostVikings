﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    public Image[] icones;

    public InventorySystem myInventory;

    public Sprite icon;
    Image myImage;
    private SpriteRenderer theRenderer;

    private string iconName;

    private int num;

    public InventorySystem _InventorySystem;

    public Sprite blank;
    public Image imageBlank;

    private int iconeSelectNum;
    private Image iconeSelect;

    private string iconeSelectName;


    void Start()
    {
        num = 0;
        iconName = "Icon"+num;
        _InventorySystem = GameObject.Find("Joueur").GetComponent<InventorySystem>();
        blank = imageBlank.sprite;
        iconeSelectNum = 0;
    }

    public void Update()
    {
        if (_InventorySystem.myCollision == true)
        {
            iconName = "Icon" + num;
            GetSpriteFrom();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("espace");
            icones[iconeSelectNum] = imageBlank;
            imageBlank = iconeSelect.GetComponent<Image>();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            iconeSelectNum -= 1;
            Debug.Log("iconeSelectNum = " + iconeSelectNum);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            iconeSelectNum += 1;
            Debug.Log("iconeSelectNum = " + iconeSelectNum);
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
        Debug.Log(num);

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