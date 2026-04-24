using UnityEngine;
using System.Collections.Generic;

public class MobController : MonoBehaviour
{
    [SerializeField] private float mobSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private int initialMobCount = 10;
    [SerializeField] private GameObject mobPrefab;
    [SerializeField] private Transform spawnPoint;

    private Vector3 targetPosition;
    private Rigidbody rb;
    private int currentMobCount;
    private List<Transform> activeMobs = new List<Transform>();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        
        targetPosition = transform.position;
        currentMobCount = initialMobCount;

        if (InputManager.Instance != null)
        {
            InputManager.Instance.OnTap += HandleTapInput;
            InputManager.Instance.OnSwipe += HandleSwipeInput;
        }

        // Spawn initial mobs
        for (int i = 0; i < initialMobCount; i++)
        {
            SpawnMob();
        }
    }

    private void OnDestroy()
    {
        if (InputManager.Instance != null)
        {
            InputManager.Instance.OnTap -= HandleTapInput;
            InputManager.Instance.OnSwipe -= HandleSwipeInput;
        }
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            MoveMobTowards(targetPosition);
        }
    }

    private void HandleTapInput(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position.y);
        
        if (groundPlane.Raycast(ray, out float enter))
        {
            targetPosition = ray.origin + ray.direction * enter;
            Debug.Log($"Mob moving to: {targetPosition}");
        }
    }

    private void HandleSwipeInput(Vector2 direction)
    {
        Vector3 worldDirection = new Vector3(direction.x, 0, direction.y).normalized;
        targetPosition = transform.position + worldDirection * 10f;
        Debug.Log($"Mob swiped towards: {worldDirection}");
    }

    private void MoveMobTowards(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        
        if (Vector3.Distance(transform.position, target) > 0.5f)
        {
            rb.velocity = new Vector3(direction.x * mobSpeed, rb.velocity.y, direction.z * mobSpeed);
            
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    private void SpawnMob()
    {
        if (mobPrefab != null)
        {
            Vector3 spawnPos = spawnPoint != null ? spawnPoint.position : transform.position + Random.insideUnitSphere * 2f;
            GameObject mob = Instantiate(mobPrefab, spawnPos, Quaternion.identity);
            activeMobs.Add(mob.transform);
        }
        else
        {
            // Create simple placeholder mob
            GameObject mob = GameObject.CreatePrimitive(PrimitiveType.Cube);
            mob.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            mob.transform.position = transform.position + Random.insideUnitSphere * 2f;
            Destroy(mob.GetComponent<Collider>());
            activeMobs.Add(mob.transform);
        }
    }

    public void AddMobCount(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnMob();
        }
        currentMobCount += amount;
        Debug.Log($"Mob count: {currentMobCount}");
    }

    public void RemoveMob()
    {
        currentMobCount--;
        if (currentMobCount <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public int GetMobCount() => currentMobCount;
    public List<Transform> GetActiveMobs() => activeMobs;
}
