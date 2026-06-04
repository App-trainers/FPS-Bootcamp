using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    [SerializeField] private KeyTypes keyType;
    private Collider enemyCollider;

    float rotationSpeed = 200f;
    float xRotation;
    float targetXRotation;
    bool isDead;

    void OnEnable()
    {
        HitEnemy();
    }

    private void Awake()
    {
        enemyCollider = GetComponent<Collider>();
    }

    void Update()
    {
        float oldXRotation = xRotation;
        xRotation = Mathf.MoveTowards(xRotation, targetXRotation, rotationSpeed * Time.deltaTime);

        float rotationAmount = xRotation - oldXRotation;
        transform.Rotate(rotationAmount, 0f, 0f);
    }

    public void HitEnemy()
    {
        if (isDead)
            return;

        float rotationAmount = 70f - xRotation;
        xRotation = 70f;
        targetXRotation = 0f;

        transform.Rotate(rotationAmount, 0f, 0f);
    }

    [ContextMenu("Kill Enemy")]
    public void KillEnemy()
    {
        if (isDead)
            return;

        isDead = true;
        targetXRotation = 70f;
        enemyCollider.isTrigger = true;

        KeySpawner.Instance.SpawnKey(keyType, transform.position + new Vector3(0, 4, 0));
    }

  
}
