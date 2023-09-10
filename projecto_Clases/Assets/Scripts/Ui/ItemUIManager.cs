using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


[System.Serializable]
public class ItemUIManager 
{
    [SerializeField] private TMP_Text pickUpItem;

    
    public void UpdatePickUPItem(Item item)
    {
        bool isValid = item != null;
        pickUpItem.text = $"Item picked up {isValid}";
    }
}
