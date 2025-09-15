using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{

    public GameObject[] playerListUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlayerJoined(PlayerInput player)
    {
        Debug.Log("player joined " + player);
        PlayerInfo newPlayer = GameData.AddPlayer(player);
        playerListUI[newPlayer.id].SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
