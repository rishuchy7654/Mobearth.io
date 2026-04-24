using UnityEngine;
using System.Collections;

public enum PowerUpType
{
    SpeedBoost,
    DamageBoost,
    HealthRestore,
    MobMultiplier,
    Shield
}

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType powerUpType = PowerUpType.SpeedBoost;
    [SerializeField] private float duration = 10f;
    [SerializeField] private float boost = 1.5f;
    [SerializeField] private ParticleSystem collectEffect;

    private bool collected = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!collected && (collision.CompareTag("Player") || collision.name.Contains("Mob")))
        {
            collected = true;
            ApplyPowerUp(collision.gameObject);
            DestroyPowerUp();
        }
    }

    private void ApplyPowerUp(GameObject player)
    {
        switch (powerUpType)
        {
            case PowerUpType.SpeedBoost:
                ApplySpeedBoost(player);
                break;
            case PowerUpType.DamageBoost:
                ApplyDamageBoost(player);
                break;
            case PowerUpType.HealthRestore:
                ApplyHealthRestore(player);
                break;
            case PowerUpType.MobMultiplier:
                ApplyMobMultiplier(player);
                break;
            case PowerUpType.Shield:
                ApplyShield(player);
                break;
        }
        Debug.Log($"Power-up applied: {powerUpType}");
        
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayCollectSound();
        }
    }

    private void ApplySpeedBoost(GameObject player)
    {
        MobController mobController = player.GetComponent<MobController>();
        if (mobController != null)
        {
            GameManager.Instance.AddScore(50);
        }
    }

    private void ApplyDamageBoost(GameObject player)
    {
        GameManager.Instance.AddScore(75);
    }

    private void ApplyHealthRestore(GameObject player)
    {
        Character character = player.GetComponent<Character>();
        if (character != null)
        {
            character.Heal(50);
        }
        GameManager.Instance.AddScore(100);
    }

    private void ApplyMobMultiplier(GameObject player)
    {
        MobController mobController = player.GetComponent<MobController>();
        if (mobController != null)
        {
            mobController.AddMobCount(10);
        }
        GameManager.Instance.AddScore(150);
    }

    private void ApplyShield(GameObject player)
    {
        GameManager.Instance.AddScore(200);
    }

    private void DestroyPowerUp()
    {
        if (collectEffect != null)
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    public PowerUpType GetPowerUpType() => powerUpType;
}
