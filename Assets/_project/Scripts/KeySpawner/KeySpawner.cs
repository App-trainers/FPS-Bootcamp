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
    public bool SpawnKey(KeyTypes keyType, Vector3 position)
    {
        if (keyType == KeyTypes.None)
            return false;

        if (_keys == null || _keys.Count == 0)
        {
            Debug.LogWarning("No key prefabs are configured on KeySpawner.", this);
            return false;
        }

        foreach (var key in _keys)
        {
            if (key == null)
                continue;

            if (keyType == key.KeyType)
            {
                Instantiate(key, position, Quaternion.identity);
                return true;
            }
        }

        Debug.LogWarning($"No key prefab configured for {keyType}.", this);
        return false;
    }
}
