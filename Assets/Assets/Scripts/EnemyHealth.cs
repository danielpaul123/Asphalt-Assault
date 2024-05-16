using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject DestroyedPrefab; // Reference to the prefab to instantiate

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Instantiate(DestroyedPrefab, transform.position, transform.rotation);
            Die();
        }
    }

    private void Die()
    {
        // Instantiate the prefab at the enemy's position and rotation
       

        // Destroy the enemy game object
        Destroy(gameObject);
    }
}
