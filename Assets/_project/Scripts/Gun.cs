using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera playerCamera;
    public ParticleSystem muzzleFlash;
    public Transform muzzle;

    public float range = 100f;
    public float damage = 20f;
    public float fireRate = 0.2f;

    private float nextTimeToFire;

    void Start()
    {
        if (playerCamera == null)
            playerCamera = GetComponentInParent<Camera>();

        if (playerCamera == null)
            playerCamera = Camera.main;
    }

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
        if (playerCamera == null)
            return;

        PlayMuzzleFlash();

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            EnemyHealth enemy = hit.collider.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
                enemy.TakeDamage(damage);
        }

        Debug.DrawRay(ray.origin, ray.direction * range, Color.red, 1f);
    }

    void PlayMuzzleFlash()
    {
        if (muzzleFlash == null || muzzle == null)
            return;

        ParticleSystem flash = Instantiate(muzzleFlash, muzzle.position, muzzle.rotation);
        flash.Play();

        Destroy(flash.gameObject, 2f);
    }
}
