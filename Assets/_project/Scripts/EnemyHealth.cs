using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Enemy enemy = GetComponentInParent<Enemy>();

        if (enemy != null)
            enemy.KillEnemy();
        else
            Destroy(gameObject);
    }
}
