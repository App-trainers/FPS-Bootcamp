using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public static KeySpawner Instance { get; private set; }

    [SerializeField] private List<Key> _keys;

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
    public void SpawnKey(KeyTypes keyType, Vector3 postion)
    {
        Debug.LogWarning("SpawnKey");
        foreach (var key in _keys)
        {
            if (keyType == KeyTypes.Gold)
            {
                Instantiate(key, postion, Quaternion.identity);
            }
            else if (keyType == KeyTypes.Silver)
            {
                Instantiate(key, postion, Quaternion.identity);
            }
            else if (keyType == KeyTypes.Bronze)
            {
                Debug.LogWarning("Bronze");
                Instantiate(key, postion, Quaternion.identity);
            }else
            {
                Debug.LogWarning("None");
            }
        }
    }
}
