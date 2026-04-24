using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string characterName = "Commander";
    [SerializeField] private int health = 100;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private Sprite characterSprite;

    private int currentHealth;
    private bool isAlive = true;

    private void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{characterName} took {damage} damage. Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, health);
        Debug.Log($"{characterName} healed. Health: {currentHealth}");
    }

    private void Die()
    {
        isAlive = false;
        Debug.Log($"{characterName} died!");
        GameManager.Instance.GameOver();
    }

    public string GetCharacterName() => characterName;
    public int GetHealth() => currentHealth;
    public float GetSpeed() => speed;
    public float GetAttackDamage() => attackDamage;
    public bool IsAlive() => isAlive;
}
