using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;

        Enemy enemy = GetComponentInParent<Enemy>();

        if (health <= 0)
        {
            Die();
            return;
        }

        if (enemy != null)
            enemy.HitEnemy();
    }

    void Die()
    {
        Enemy enemy = GetComponentInParent<Enemy>();

        if (enemy != null)
            enemy.KillEnemy();
    }
}
