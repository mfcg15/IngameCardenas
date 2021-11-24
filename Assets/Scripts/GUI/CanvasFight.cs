using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasFight : MonoBehaviour
{
    public void ClickBackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
