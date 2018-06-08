using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour {

    public XboxController controller;

    // Update is called once per frame
    void Update ()
    {
        if (XCI.GetButton(XboxButton.Start, controller))
        {
            SceneManager.LoadScene("Main");
        }
        if (XCI.GetButton(XboxButton.Back, controller))
        {
            Debug.Log("Game Quit");
            Application.Quit();
        }

    }
}
