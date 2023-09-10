using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[System.Serializable]
public class PlayerUIManager 
{
    [SerializeField] private TMP_Text playerHelthText;
    [SerializeField] private TMP_Text wallHelthText;

    private Dictionary<string, Action<int>> actorActionOnUPdateHealth = new();

  
    public void UpdateActorHealth(string actorID, int healthLeft)
    {
        if(actorActionOnUPdateHealth == null)
        {
            InitializeDictionary();
        }
        if (actorActionOnUPdateHealth.TryGetValue(actorID, out var onUpdateHealth))
        {
            onUpdateHealth.Invoke(healthLeft);
        }
    }
    private void InitializeDictionary()
    {
        actorActionOnUPdateHealth = new()
        {
            { ActorConstants.WALL_ID, UpdateWallHelth },
            { ActorConstants.PLAYER_ID, UpdatePlayerHelth }
        };
        
    }

    private void UpdatePlayerHelth(int playerHealth)
    {
        playerHelthText.text = playerHealth.ToString();
    }

    private void UpdateWallHelth(int wallHealth)
    {
        wallHelthText.text = wallHealth.ToString();
    }
}
