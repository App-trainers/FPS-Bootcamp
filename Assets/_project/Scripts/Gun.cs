using UnityEngine;


public class Gun : MonoBehaviour
{
    public Camera playerCamera;
    public ParticleSystem muzzleFlash;

    public float range = 100f;
    public float damage = 20f;
    public float fireRate = 0.2f;

    float nextTimeToFire;
    public Transform muzzle;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(cameraRay, out hit, range))
            targetPoint = hit.point;
        else
            targetPoint = cameraRay.GetPoint(range);

        Vector3 direction = (targetPoint - muzzle.position).normalized;

        if (Physics.Raycast(muzzle.position, direction, out hit, range))
        {
            Debug.Log("Hit: " + hit.collider.name);

            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
                enemy.TakeDamage(damage);
        }

        Debug.DrawRay(muzzle.position, direction * range, Color.red, 1f);
    }
}