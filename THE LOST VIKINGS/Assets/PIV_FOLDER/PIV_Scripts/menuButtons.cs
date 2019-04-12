using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    
    public class menuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void launchScene()
    {
        SceneManager.LoadScene("ARH_Scene");
        Debug.Log("Scene loaded");
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("game closed");
    }

}
