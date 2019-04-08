using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    public List<Image> listIcons = new List<Image>();

    public XboxController myCurrentPlayer;

    public Sprite icon;
    private Image myImage;

    private string iconName;

    [SerializeField]
    private int num;

    [SerializeField]
    private int blankCounter = 4;

    public InventorySystem _InventorySystem;

    public Sprite blank;
    private Image imageBlank;

    private int iconeSelectNum;

    [SerializeField]
    private int iconeSelectNumFixed;

    void Start()
    {
        num = 0;
        iconName = "Icon"+num;
        imageBlank.sprite = blank;
        iconeSelectNum = 0;
    }

    public void Update()
    {
        iconeSelectNum = Mathf.Clamp(iconeSelectNum, 0, num - 1);
        iconeSelectNumFixed = iconeSelectNum + 1;

        if (_InventorySystem.myCollision == true)
        {
            SpriteRenderer theRenderer = _InventorySystem.objetInventaire.GetComponent<SpriteRenderer>();
            listIcons[num].sprite = theRenderer.sprite;
            num++;
            num = Mathf.Clamp(num, 0, 4);
            blankCounter--;
        }
        if(myCurrentPlayer.thisIsSelected == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                listIcons[iconeSelectNum].sprite = blank;
                blank.name = "Blank";
                num--;
                num = Mathf.Clamp(num, 0, 4);
                blankCounter++;

                SpriteSorter();

                _InventorySystem.objectCounter -= 1;

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

    }

    public void SpriteSorter()
    {

                Sprite tempItem3 = listIcons[3].sprite;
                Sprite tempItem2 = listIcons[2].sprite;
                Sprite tempItem1 = listIcons[1].sprite;
                Sprite tempItem0 = listIcons[0].sprite;

                if (listIcons[0].sprite.name == "Blank")
                {
                    listIcons[0].sprite = tempItem1;
                    listIcons[1].sprite = tempItem2;
                    listIcons[2].sprite = tempItem3;
                }

                if (listIcons[1].sprite.name == "Blank")
                {
                    listIcons[1].sprite = tempItem2;
                    listIcons[2].sprite = tempItem3;
                }

                if (listIcons[2].sprite.name == "Blank")
                {
                    listIcons[2].sprite = tempItem3;
                }


                listIcons[listIcons.Count - blankCounter].sprite = blank;

    }
}