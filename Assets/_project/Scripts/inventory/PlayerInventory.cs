using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    //index0=bronze // index1=silver // index2=gold
    [SerializeField] private List<GameObject> keyUIs = new List<GameObject>();
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
            UpdateKeyUI(key, true);
            
            Debug.Log("Key added: " + key);
            
        }
    }

    public bool TryGetKey(KeyTypes keyType)
    {
        if (collectedKeys.Contains(keyType))
        {
            collectedKeys.Remove(keyType);
            UpdateKeyUI(keyType, false);
            
            Debug.Log("Key used: " + keyType);
            return true;
        }

        return false;
    }

    private void UpdateKeyUI(KeyTypes keyType, bool state)
    {
        switch (keyType)
        {
            case KeyTypes.Bronze: keyUIs[0].SetActive(state);
            break;

            case KeyTypes.Silver: keyUIs[1].SetActive(state);
            break;
            case KeyTypes.Gold: keyUIs[2].SetActive(state);
            break;
            
            default: Debug.Log("oh nine u no key");
            break;
        }
    }
}