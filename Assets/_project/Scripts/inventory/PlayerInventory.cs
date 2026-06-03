using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    private List<KeyTypes> _collectedKeys = new List<KeyTypes>();

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

    public void AddKeyToInventory (KeyTypes key)
    {
        if (!_collectedKeys.Contains(key))
        {
            _collectedKeys.Add(key);
        }
    }   

    public bool TryGetKey(KeyTypes keyTypes)
    {
        foreach (var key in _collectedKeys)
        {
            if (key == keyTypes)
            {
                Debug.LogWarning("Key used: " + key);
                _collectedKeys.Remove(key);
                return true;
            }
        }
        return false;
    }
}
