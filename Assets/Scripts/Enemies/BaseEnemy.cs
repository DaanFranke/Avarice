using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    //Health
    public float maxHealth;
    public float currentHealth;

    //Speed
    public float movementSpeed;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void DamageTaken(float damage) 
    { 
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy killed");
        }
    }
}
