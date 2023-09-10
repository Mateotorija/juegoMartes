using Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor, IListener
{
    [SerializeField] private string eventID;

    private static EventsManager EventsManager => EventsManager.Instance;

    public void OnEventDispatch()
    {
        TakeDamage(CurentLife);
        EventsManager.RemoveListener(eventID, this);
    }

    

    private void Start()
    {
        base.Start();
        EventsManager.AddListener(eventID, this);
    }
}



