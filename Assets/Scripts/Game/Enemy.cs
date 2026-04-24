using UnityEngine;

public enum EnemyType
{
    Soldier,
    Civilian,
    Zombie,
    Robot
}

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType = EnemyType.Soldier;
    [SerializeField] private int health = 50;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float attackRange = 2f;

    private int currentHealth;
    private Transform target;
    private Rigidbody rb;
    private bool isAlive = true;

    private void Start()
    {
        currentHealth = health;
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        if (!isAlive) return;

        FindTarget();
        if (target != null)
        {
            ChaseTarget();
        }
    }

    private void FindTarget()
    {
        if (target == null || Vector3.Distance(transform.position, target.position) > detectionRange * 2)
        {
            // Find mob controller
            MobController mobController = FindObjectOfType<MobController>();
            if (mobController != null)
            {
                target = mobController.transform;
            }
        }
    }

    private void ChaseTarget()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget > attackRange)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);
        }
        else
        {
            // Attack target
            Attack();
        }
    }

    private void Attack()
    {
        // Implement attack logic
        if (target.TryGetComponent<Character>(out Character character))
        {
            character.TakeDamage((int)damage);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log($"Enemy {enemyType} took {damageAmount} damage. Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isAlive = false;
        Debug.Log($"Enemy {enemyType} defeated!");
        GameManager.Instance.OnEnemyDefeated();
        Destroy(gameObject, 0.5f);
    }

    public int GetHealth() => currentHealth;
    public bool IsAlive() => isAlive;
    public EnemyType GetEnemyType() => enemyType;
}
