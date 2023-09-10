using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public interface IPlayerUIManagerProvider
{
    PlayerUIManager PlayerUIManager { get; }
}

public interface IItemUIManagerProvider
{
    ItemUIManager ItemUIManager { get;  }
}
public class UIManager : MonoBehaviour, IPlayerUIManagerProvider, IItemUIManagerProvider
{
    
    public static UIManager Instance;

    [SerializeField] private PlayerUIManager playerUIManager;
    public PlayerUIManager PlayerUIManager => playerUIManager;

    [SerializeField] private ItemUIManager itemUIManager;

    public ItemUIManager ItemUIManager => itemUIManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
 
    }
   
}
