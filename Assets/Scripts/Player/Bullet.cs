using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 3f;
    public int damage = 1;

    private Vector3 moveDirection;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke(nameof(DeactivateBullet), lifeTime);
    }

    private void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            DeactivateBullet();
        }
    }

    private void DeactivateBullet()
    {
        gameObject.SetActive(false);
    }
}