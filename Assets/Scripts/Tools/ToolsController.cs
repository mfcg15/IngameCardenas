using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsController : MonoBehaviour
{
    [SerializeField] GameManager.typesTools typetool;

    public GameManager.typesTools GetTypeTool()
    {
        return typetool;
    }
}
