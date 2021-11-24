using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasInventory : MonoBehaviour
{
    [SerializeField] private Text textCannedFood, textFirstaid, textWalkie, textWatterBottle;
    [SerializeField] private InventoryController inventory;
    [SerializeField] private GameObject panelTools;

    void Start()
    {
        panelTools.SetActive(false);
    }

    void Update()
    {
        UpdateCountTool();
    }

    void UpdateCountTool()
    {
        int[] toolCount = inventory.GetToolQuantity();
        textCannedFood.text = "x" + toolCount[0];
        textFirstaid.text = "x" + toolCount[1];
        textWalkie.text = "x" + toolCount[2];
        textWatterBottle.text = "x" + toolCount[3];
    }

    public void TooglePanel()
    {
        panelTools.SetActive(!panelTools.activeSelf);
    }

    public void ClickBackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
