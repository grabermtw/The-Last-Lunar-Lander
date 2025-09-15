using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;


public class PlayerInfo
{
    public int id;
    public InputDevice[] inputDevices;

    public PlayerInfo(int id, InputDevice[] inputDevices)
    {
        this.id = id;
        this.inputDevices = inputDevices;
        Debug.Log("new device deviceClass" + inputDevices[0].description.deviceClass);
        Debug.Log("new device capabilties" + inputDevices[0].description.capabilities);
        Debug.Log("new device product" + inputDevices[0].description.product);
    }
}

public static class GameData
{
    public static List<PlayerInfo> players;

    public static PlayerInfo AddPlayer(PlayerInput playerInput)
    {
        if (players == null)
        {
            players = new List<PlayerInfo>();
        }
        PlayerInfo newPlayerInfo = new PlayerInfo(players.Count, playerInput.devices.ToArray());
        players.Add(newPlayerInfo);
        return newPlayerInfo;
    }

    public static PlayerInfo UpdatePlayer(int id, PlayerInput playerInput)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].id == id)
            {
                players[i].inputDevices = playerInput.devices.ToArray();
                return players[i];
            }
        }
        return null;
    }

}

