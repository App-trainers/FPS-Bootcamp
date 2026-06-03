using System;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    [SerializeField] private KeyTypes keyType;

    [ContextMenu("Kill Enemy")]
    public void KillEnemy()
    {
        Debug.LogWarning($"{keyType.ToString()}");
        KeySpawner.Instance.SpawnKey(keyType, transform.position - new Vector3(0, .25f, 0));
        Destroy(gameObject);
    }
}
