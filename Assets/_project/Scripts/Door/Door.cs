using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private KeyTypes _doorKeyType;

    [SerializeField] private float openYRotation = 90f;

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isOpen;

    private void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y + openYRotation,
            transform.eulerAngles.z
        );
    }

    [ContextMenu("Trigger Door")]
    public void TriggerDoor()
    {
        if (PlayerInventory.Instance.TryGetKey(_doorKeyType))
        {
            if (isOpen)
                CloseDoor();
            else
                OpenDoor();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(IsKeyCollected())
                TriggerDoor();
        }
    }

    private bool IsKeyCollected()
    {
        if (PlayerInventory.Instance.TryGetKey(_doorKeyType))
        {
            return true;
        }
        return false;
    }

    private void OpenDoor()
    {
            transform.rotation = openRotation;
            isOpen = true;
        
    }

    private void CloseDoor()
    {
        transform.rotation = closedRotation;
        isOpen = false;
    }
}