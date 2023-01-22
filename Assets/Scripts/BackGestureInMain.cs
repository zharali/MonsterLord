using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGestureInMain : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitApplication();
        }
    }

    public void QuitApplication()
    {
        Debug.Log("Quitting application");
        Application.Quit();
    }
}
