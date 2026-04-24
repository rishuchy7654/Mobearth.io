using UnityEngine;

public enum WeaponType
{
    Gun,
    Net,
    Shield,
    Freeze,
    Lightning
}

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponType weaponType = WeaponType.Gun;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float range = 20f;
    [SerializeField] private GameObject projectilePrefab;

    private float lastFireTime = 0f;

    public void Fire(Vector3 direction)
    {
        if (Time.time - lastFireTime >= 1f / fireRate)
        {
            CreateProjectile(direction);
            lastFireTime = Time.time;
            Debug.Log($"Fired {weaponType} weapon");
        }
    }

    private void CreateProjectile(Vector3 direction)
    {
        if (projectilePrefab != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = projectile.AddComponent<Rigidbody>();
            }
            rb.velocity = direction.normalized * 20f;
            Destroy(projectile, 5f);
        }
    }

    public float GetDamage() => damage;
    public WeaponType GetWeaponType() => weaponType;
    public float GetRange() => range;
}
