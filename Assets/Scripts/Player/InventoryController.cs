using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    [SerializeField] private int[] toolQuantity = { 0, 0, 0, 0 };

    public void CountTool(GameObject tool)
    {
        ToolsController t = tool.GetComponent<ToolsController>();
        switch (t.GetTypeTool())
        {
            case GameManager.typesTools.CannedFood:
                toolQuantity[0]++;
                break;
            case GameManager.typesTools.Firstaid:
                toolQuantity[1]++;
                break;
            case GameManager.typesTools.Walkie:
                toolQuantity[2]++;
                break;
            case GameManager.typesTools.WaterBottle:
                toolQuantity[3]++;
                break;
            default:
                Debug.Log("Tool no encontrado");
                break;
        }
    }

    public int[] GetToolQuantity()
    {
        return toolQuantity;
    }
}
