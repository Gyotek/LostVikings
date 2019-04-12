using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serrure : MonoBehaviour
{
    public XboxController olafController;
    public XboxController erikController;
    public XboxController baleogController;

    public IconManager olafIconManager;
    public IconManager erikIconManager;
    public IconManager baleogIconManager;

    [SerializeField] private Collider2D col;

    [SerializeField] private GameObject porte;

    [SerializeField] private Sprite key;


    public Animation animPorte;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void isKey()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Olaf")
        {
            for (int i = 0; i < 3; i++)
            {
                if (olafIconManager.listIcons[i].sprite == key)
                {
                    animPorte.Play("Porte");
                    col.enabled = false;
                    olafIconManager.RemoveKey(i);
                }
            }
        }
        else if (collision.gameObject.tag == "Erik")
        {
            for (int i = 0; i < 3; i++)
            {
                if (erikIconManager.listIcons[i].sprite == key)
                {
                    animPorte.Play("Porte");
                    col.enabled = false;
                    erikIconManager.RemoveKey(i);
                }
            }
        }
        else if (collision.gameObject.tag == "Baleog")
        {
            for (int i = 0; i < 3; i++)
            {
                if (baleogIconManager.listIcons[i].sprite == key)
                {
                    animPorte.Play("Porte");
                    col.enabled = false;
                    baleogIconManager.RemoveKey(i);
                }
            }
        }
    }
}
