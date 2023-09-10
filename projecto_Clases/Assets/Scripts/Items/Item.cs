using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private static IItemUIManagerProvider uiProvider = UIManager.Instance;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            character.PickUPItem(this);
            uiProvider.ItemUIManager.UpdatePickUPItem(this);
        }
    }
}
