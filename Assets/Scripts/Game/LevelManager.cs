using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int enemyCount = 5;
    [SerializeField] private int powerUpCount = 3;
    [SerializeField] private Vector3 levelBounds = new Vector3(50, 10, 50);
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private Transform goalPosition;

    private int enemiesDefeated = 0;
    private bool levelComplete = false;

    private void Start()
    {
        SpawnEnemies();
        SpawnPowerUps();
        Debug.Log($"Level {GameManager.Instance.GetCurrentLevel()} started!");
    }

    private void Update()
    {
        CheckLevelCompletion();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPos = GetRandomSpawnPosition();
            if (enemyPrefab != null)
            {
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }
            else
            {
                // Create placeholder enemy
                GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                enemy.GetComponent<Renderer>().material.color = Color.red;
                enemy.transform.position = spawnPos;
                Destroy(enemy.GetComponent<Collider>());
                enemy.AddComponent<Enemy>();
            }
        }
    }

    private void SpawnPowerUps()
    {
        for (int i = 0; i < powerUpCount; i++)
        {
            Vector3 spawnPos = GetRandomSpawnPosition();
            if (powerUpPrefab != null)
            {
                Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
            }
            else
            {
                // Create placeholder power-up
                GameObject powerUp = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                powerUp.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                powerUp.GetComponent<Renderer>().material.color = Color.yellow;
                powerUp.transform.position = spawnPos;
                Destroy(powerUp.GetComponent<Collider>());
                powerUp.AddComponent<PowerUp>();
            }
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(
            Random.Range(-levelBounds.x / 2, levelBounds.x / 2),
            0.5f,
            Random.Range(-levelBounds.z / 2, levelBounds.z / 2)
        );
    }

    private void CheckLevelCompletion()
    {
        if (levelComplete) return;

        // Check if player reached goal
        MobController mobController = FindObjectOfType<MobController>();
        if (mobController != null && goalPosition != null)
        {
            float distanceToGoal = Vector3.Distance(mobController.transform.position, goalPosition.position);
            if (distanceToGoal < 2f)
            {
                levelComplete = true;
                GameManager.Instance.LevelComplete();
            }
        }

        // Check if all enemies defeated
        Enemy[] remainingEnemies = FindObjectsOfType<Enemy>();
        if (remainingEnemies.Length == 0 && enemyCount > 0)
        {
            levelComplete = true;
            GameManager.Instance.LevelComplete();
        }
    }

    public void OnEnemyDefeated()
    {
        enemiesDefeated++;
    }
}
