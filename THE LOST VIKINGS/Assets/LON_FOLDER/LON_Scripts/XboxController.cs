using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class XboxController : MonoBehaviour
{

    public bool olafSelected = false;
    public bool erikSelected = false;
    public bool baleogSelected = false;

    public bool isGrounded;
    public bool canClimb;

    public List<CinemachineVirtualCamera> cameraList = new List<CinemachineVirtualCamera>();
    public List<Rigidbody2D> rbList = new List<Rigidbody2D>();
    public List<GameObject> charactersList = new List<GameObject>();
    public List<XboxController> controllerScriptList = new List<XboxController>();

    [SerializeField]
    Collider2D[] isGroundedArray;

    public float overlapBoxX;
    public float overlapBoxY;
    public float offsetBox;

    public LayerMask isGroundedLayer;

    public float speed;

    [SerializeField]
    private int index = 0;

    [Range(0, 1), SerializeField]
    private float speedValue = 0.5f;

    private Rigidbody2D rb;


    // [INDEX VALUES]
    //   0 = Olaf
    //   1 = Erik
    //   2 = Baleog


    // Start
    void Start()
    {
            olafSelected = true;
            erikSelected = false;
            baleogSelected = false;

        rb = this.GetComponent<Rigidbody2D>();     
    }

    // Update
    void Update()
    {
        Selection();
        CameraFocus();
    }

    // Fixed Update
    void FixedUpdate()
    {
        MovingSystem();
    }

    public void Selection()
    {
        if (Input.GetKeyDown("joystick 1 button 3") && charactersList.Count > 1)
        {

            if (index >= charactersList.Count - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }

            if (charactersList[index].tag == "Olaf")
            {
                olafSelected = true;
                erikSelected = false;
                baleogSelected = false;

            }
            else if (charactersList[index].tag == "Erik")
            {
                olafSelected = false;
                erikSelected = true;
                baleogSelected = false;
            }
            else if (charactersList[index].tag == "Baleog")
            {
                olafSelected = false;
                erikSelected = false;
                baleogSelected = true;
            }
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
        if(this.isGrounded == true)
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
            else if (index == controllerScriptList.Count) 
            {
                if(controllerScriptList[0].isGrounded == true)
                {
                    StartCoroutine("BodyTypeChanger");
                }
            }

            ////////////////////////////////////////////////////////////////////////// Si je joue OLAF et que son BodyType l'autorise à bouger
            if (olafSelected == true && rb.bodyType == RigidbodyType2D.Dynamic)
            {
                if (xAxis > 0.3) //Aller à droite avec OLAF
                {
                    this.transform.Translate(Vector3.right * speed * Time.deltaTime);
                }

                if (xAxis < -0.3) //Aller à gauche avec OLAF
                {
                    this.transform.Translate(-Vector3.right * speed * Time.deltaTime);
                }

                if (yAxis < -0.3 && canClimb == true)
                {
                    this.transform.Translate(-Vector3.up * speed * Time.deltaTime);
                }

                if (yAxis > 0.3 && canClimb == true)
                {
                    this.transform.Translate(Vector3.up * speed * Time.deltaTime);
                }
            }
            ////////////////////////////////////////////////////////////////////////// Si je joue ERIK et que son BodyType l'autorise à bouger
            else if (erikSelected == true && rb.bodyType == RigidbodyType2D.Dynamic)
            {
                if (xAxis > 0.3) //Aller à droite avec ERIK
                {
                    this.transform.Translate(Vector3.right * speed * Time.deltaTime);
                }

                if (xAxis < -0.3) //Aller à gauche avec ERIK
                {
                    this.transform.Translate(-Vector3.right * speed * Time.deltaTime);
                }

                if (yAxis < -0.3 && canClimb == true)
                {
                    this.transform.Translate(-Vector3.up * speed * Time.deltaTime);
                }

                if (yAxis > 0.3 && canClimb == true)
                {
                    this.transform.Translate(Vector3.up * speed * Time.deltaTime);
                }
            }
            ////////////////////////////////////////////////////////////////////////// Si je joue BALEOG et que son BodyType l'autorise à bouger
            else if (baleogSelected == true && rb.bodyType == RigidbodyType2D.Dynamic)
            {
                if (xAxis > 0.3) //Aller à droite avec BALEOG
                {
                    this.transform.Translate(Vector3.right * speed * Time.deltaTime);
                }

                if (xAxis < -0.3) //Aller à gauche avec BALEOG
                {
                    this.transform.Translate(-Vector3.right * speed * Time.deltaTime);
                }

                if (yAxis < -0.3 && canClimb == true)
                {
                    this.transform.Translate(-Vector3.up * speed * Time.deltaTime);
                }

                if (yAxis > 0.3 && canClimb == true)
                {
                    this.transform.Translate(Vector3.up * speed * Time.deltaTime);
                }
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


    // POUR FAIRE LES DÉPLACEMENTS AVEC DES FORCES :     //rb.AddForce(transform.right * speedValue, ForceMode2D.Impulse);

}
