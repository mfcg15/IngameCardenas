using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasWelcome : MonoBehaviour
{
    [SerializeField] private InputField txtUserName;

    public void OnClickAccept()
    {
        if (txtUserName.text == "")
        {
            Debug.Log("Debe ingresar un nombre");
        }
        else
        {
            WelcomeManager.instance.SetPlayerName(txtUserName.text);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
