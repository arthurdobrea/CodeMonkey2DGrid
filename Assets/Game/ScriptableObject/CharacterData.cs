using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    
    public UnityEvent onDeath;
    public UnityEvent<float> onHpChanged;

    public float Health
    {
        get => currentHealth;
        set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            onHpChanged?.Invoke(currentHealth);
            
            Debug.Log("Current health: " + currentHealth);
            if(currentHealth <= 0)
            {
                Debug.Log("Character died");
                onDeath?.Invoke();
            }
        }
    }

    public void TakeDamage(float damage)
    {
        float currentHealth = Health;
        float newHealth = currentHealth - damage;
        Health = newHealth;
    }
}