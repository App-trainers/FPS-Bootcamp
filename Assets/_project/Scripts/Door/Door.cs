using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private KeyTypes doorKeyType;
    [SerializeField] private float openYRotation = 90f;
    [SerializeField] private bool openToRight = true;
    [SerializeField] private bool openToOutside = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TryOpenDoor();
        }
    }

    private void TryOpenDoor()
    {
        if (!PlayerInventory.Instance.TryGetKey(doorKeyType)) return;

        OpenDoor();
    }

    [ContextMenu("Open Door")]
    private void OpenDoor()
    {
        float rightOrLeft = openToRight ? 1f : -1f;
        float insideOrOutside = openToOutside ? 1f : -1f;

        transform.Rotate(0f, openYRotation * rightOrLeft * insideOrOutside, 0f);
    }
}
