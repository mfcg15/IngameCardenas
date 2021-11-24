using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasMainMenu : MonoBehaviour
{
    [SerializeField] private Text textUserName;
   

    private void Start()
    {
        textUserName.text = "Hola " +WelcomeManager.instance.GetPlayerName();
        
    }

    public void OnClickInventory()
    {
        SceneManager.LoadScene("Inventory");

    }

    public void OnClickFight()
    {
        SceneManager.LoadScene("Fight");

    }
}
