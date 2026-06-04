using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private KeyTypes doorKeyType;
    [SerializeField] private float openYRotation = 90f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TryOpenDoor();
        }
    }

    [ContextMenu("Open Door")]
    private void TryOpenDoor()
    {
            if (!PlayerInventory.Instance.TryGetKey(doorKeyType)) return;

            transform.Rotate(0f, openYRotation, 0f);
    }
}