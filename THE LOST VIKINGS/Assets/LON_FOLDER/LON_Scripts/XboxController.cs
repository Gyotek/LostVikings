using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class XboxController : MonoBehaviour
{
    
    public bool olafSelected = false;
    public bool erikSelected = false;
    public bool baleogSelected = false;

    public List<CinemachineVirtualCamera> cameraList = new List<CinemachineVirtualCamera>();
    public List<GameObject> charactersList = new List<GameObject>();

    [SerializeField]
    private int index = 0;

    [Range(0,1), SerializeField]
    private float speedValue = 0.5f;

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

    // Update
    void Update()
    {
        Selection();
        CameraFocus();
        MovingSystem();
    }


    public void Selection()
    {
        if (Input.GetKeyDown("joystick 1 button 3") && charactersList.Count > 1)
        {

            if (index+2 > charactersList.Count)
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
        foreach(CinemachineVirtualCamera cam in cameraList)
        {
            if(cam != cameraList[index])
            {
                cam.enabled = false;
            }
            else if(cam == cameraList[index])
            {
                cam.enabled = true;
            }
        }
    }

    public void MovingSystem()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        if(olafSelected == true)
        {
            if(xAxis > 0.3)
            {
                rb.AddForce(transform.right * speedValue, ForceMode2D.Impulse);
            }

            if(xAxis < 0.3)
            {
                rb.AddForce(transform.right * -speedValue, ForceMode2D.Impulse);
            }

        }
        else if (erikSelected == true)
        {

        }
        else if(baleogSelected == true)
        {

        }
    }
}
