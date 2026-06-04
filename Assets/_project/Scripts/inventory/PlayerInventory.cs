using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    private List<KeyTypes> collectedKeys = new List<KeyTypes>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddKeyToInventory(KeyTypes key)
    {
        if (key == KeyTypes.None)
        {
            Debug.LogWarning("Trying to add None key. Check the key prefab Inspector.");
            return;
        }

        if (!collectedKeys.Contains(key))
        {
            collectedKeys.Add(key);
            Debug.Log("Key added: " + key);
        }
    }

    public bool TryGetKey(KeyTypes keyType)
    {
        if (collectedKeys.Contains(keyType))
        {
            collectedKeys.Remove(keyType);
            Debug.Log("Key used: " + keyType);
            return true;
        }

        return false;
    }
}