using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class XboxController : MonoBehaviour
{

    public bool thisIsSelected = false;

    public bool isGrounded;
    public bool canClimb;

    public int hp = 100;

    public List<CinemachineVirtualCamera> cameraList = new List<CinemachineVirtualCamera>();
    public List<Rigidbody2D> rbList = new List<Rigidbody2D>();
    public List<GameObject> charactersList = new List<GameObject>();
    public List<XboxController> controllerScriptList = new List<XboxController>();

    [SerializeField]
    Collider2D[] isGroundedArray;

    public float overlapBoxX;
    public float overlapBoxY;
    public float offsetBox;

    public float xJoystick;

    public LayerMask isGroundedLayer;

    public float speed;

   
    public int index;

    private Rigidbody2D rb;


    // [INDEX VALUES]
    //   0 = Olaf
    //   1 = Erik
    //   2 = Baleog

    // Start
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();     
    }

    /*
     * 
     * 
     * FAIRE EN SORTE QU'ON NE PUISSE PAS S'ARRÊTER DANS LES AIRS
     * 
     * 
     */


    // Update
    void Update()
    {
        Selection();
        CameraFocus();
        xJoystick = Input.GetAxis("Horizontal");
    }

    // Fixed Update
    void FixedUpdate()
    {
        MovingSystem();
    }

    public void Selection()
    {
        if (this.gameObject.tag == controllerScriptList[index].gameObject.tag)
        {
            this.thisIsSelected = true;
        }
        else
        {
            this.thisIsSelected = false;
        }

        if ((Input.GetKeyDown("joystick 1 button 3") || Input.GetKeyDown("space")) && charactersList.Count > 1 && this.gameObject.tag == charactersList[index].tag && this.isGrounded == true)
        {
            StartCoroutine("SelectionCoroutine");
        }
    }

    public void CameraFocus()
    {
        foreach (CinemachineVirtualCamera cam in cameraList)
        {
            if (cam != cameraList[index])
            {
                cam.enabled = false;
            }
            else if (cam == cameraList[index])
            {
                cam.enabled = true;
            }
        }
    }

    //Dessiner l'OverlapCircle sur l'Editeur
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position - new Vector3(0, offsetBox, 0), new Vector2(overlapBoxX, overlapBoxY));
    }

    public void MovingSystem()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        //Système d'Overlap avec radius et offset tweakable pour détecter si le personnage est au sol ou non
        isGroundedArray = Physics2D.OverlapBoxAll(transform.position - new Vector3(0, offsetBox, 0), new Vector2(overlapBoxX,overlapBoxY), 0, isGroundedLayer);

        if(isGroundedArray.Length == 0)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
        
        //Est-ce que ce personnage est au sol ?
        if(this.isGrounded == true && this.thisIsSelected == true)
        {
            //Si je n'ai pas atteint le bout de la liste, je regarde si le prochain personnage (avec qui on va swap) est au sol aussi ?
            if(index < controllerScriptList.Count - 1)
            {
                if (controllerScriptList[index + 1].isGrounded == true)
                {
                    StartCoroutine("BodyTypeChanger");
                }
            }
            //Pour éviter un OutOfBoundsException, si j'ai atteint le bout de la liste je teste la valeur 0 (qui suit la dernière valeur pour faire une boucle). Je teste donc si le premier personnage est au sol.
            else if (index == controllerScriptList.Count - 1) 
            {
                if(controllerScriptList[0].isGrounded == true)
                {
                    StartCoroutine("BodyTypeChanger");
                }
            }
        }
        //Autoriser le personnage sélectionné à bouger.
        if (thisIsSelected == true && rb.bodyType == RigidbodyType2D.Dynamic)
        {
            if (xAxis > 0.3) //Aller à droite
            {
                this.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            if (xAxis < -0.3) //Aller à gauche
            {
                this.transform.Translate(-Vector3.right * speed * Time.deltaTime);
            }

            if (yAxis < -0.3 && canClimb == true) //Descendre à l'échelle si cela est autorisé
            {
                this.transform.Translate(-Vector3.up * speed * Time.deltaTime);
            }

            if (yAxis > 0.3 && canClimb == true) //Monter à l'échelle si cela est autorisé
            {
                this.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }

    //Attendre que tous les personnages soient bien au sol
    IEnumerator BodyTypeChanger()
    {
        yield return new WaitForSeconds(0.1f);

        foreach (Rigidbody2D rigidbody in rbList)
        {
            if (rigidbody != rbList[index])
            {
                rigidbody.bodyType = RigidbodyType2D.Static;
            }
            else if (rigidbody == rbList[index])
            {
                rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    IEnumerator SelectionCoroutine()
    {
        yield return new WaitForSeconds(0.1f);

        if (index >= charactersList.Count - 1)
        {
            for(int i = 0; i < controllerScriptList.Count; i++)
            {
                Debug.Log("Index set to 0");
                controllerScriptList[i].index = 0;                
            }
        }
        else
        {
            for (int i = 0; i < controllerScriptList.Count; i++)
            {
                Debug.Log("Index set to ++");
                controllerScriptList[i].index++;
            }
        }
    }

    // POUR FAIRE LES DÉPLACEMENTS AVEC DES FORCES :     //rb.AddForce(transform.right * speed (entre 0 et 1) , ForceMode2D.Impulse);

}
