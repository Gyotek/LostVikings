using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManagerScript : MonoBehaviour
{
    public float timeBeforeLoss = 120.0f;

    public Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(second());
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = "Timer : " + timeBeforeLoss.ToString();

        if (timeBeforeLoss <= 0)
        {

        }
    } 

    public IEnumerator second()
    {
        yield return new WaitForSeconds(1);
        timeBeforeLoss--;
        StartCoroutine(second());
    }
}
