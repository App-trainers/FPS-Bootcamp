using UnityEngine;

public class Key : MonoBehaviour
{
    public KeyTypes KeyType;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerInventory.Instance.AddKeyToInventory(this.KeyType);
                Destroy(gameObject); 
            }
    }
}
