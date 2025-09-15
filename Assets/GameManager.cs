using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    PlayerInputManager playerInputManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerInputManager.playerPrefab = this.playerPrefab;
        for (int i = 0; i < GameData.players.Count; i++)
        {
            PlayerInput newPlayer = playerInputManager.JoinPlayer(GameData.players[i].id, -1, null, GameData.players[i].inputDevices);
            InputDevice[] devices = GameData.players[i].inputDevices;
            newPlayer.transform.position = newPlayer.transform.position + new Vector3(5 * i,0,0);
            GameData.UpdatePlayer(GameData.players[i].id, newPlayer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
