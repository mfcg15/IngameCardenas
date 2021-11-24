using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeManager : MonoBehaviour
{
    public static WelcomeManager instance;

    [SerializeField] private string playerName;


    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerName(string newNamePlayer)
    {
        playerName = newNamePlayer;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

}
