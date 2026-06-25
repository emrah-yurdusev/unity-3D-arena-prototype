using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public BulletPool bulletPool;

    public float fireCooldown = 0.3f;

    private float nextFireTime;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    private void Shoot()
    {
        GameObject bulletObject = bulletPool.GetBullet();

        if (bulletObject == null) return;

        bulletObject.transform.position = firePoint.position;
        bulletObject.transform.rotation = firePoint.rotation;

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetDirection(transform.forward);

        bulletObject.SetActive(true);
    }
}