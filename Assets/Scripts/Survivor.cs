using UnityEngine;

public class Survivor : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;

    [field: SerializeField] public float MoveSpeed { get; private set; }

    public void Move(float direction)
    {
        rb.linearVelocity = new Vector3(direction * MoveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
    }

    public void Hurt(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > MaxHealth) currentHealth = MaxHealth;
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Survivor has died.");
    }
}
