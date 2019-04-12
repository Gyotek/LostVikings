using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSystem : MonoBehaviour
{

    public List<GameObject> charactersList = new List<GameObject>();

    [SerializeField]
    private int index = 0;

    // [INDEX VALUES]
    //   0 = Olaf
    //   1 = Erik
    //   2 = Baleog

    public void Selection()
    {
        if(Input.GetKeyDown("joystick 1 button 3") && charactersList.Count > 1)
        {
            if(index > charactersList.Count)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }
}
