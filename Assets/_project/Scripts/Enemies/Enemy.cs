using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    [SerializeField] private KeyTypes keyType;

    [ContextMenu("Kill Enemy")]
    public void KillEnemy()
    {
        if (KeySpawner.Instance != null)
            KeySpawner.Instance.SpawnKey(keyType, transform.position - new Vector3(0, .25f, 0));

        Destroy(gameObject);
    }
}
