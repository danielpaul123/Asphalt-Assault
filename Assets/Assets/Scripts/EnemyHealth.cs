using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject DestroyedPrefab; // Reference to the prefab to instantiate
    public AudioClip destroySound; // Sound to play when the enemy is destroyed
    public ParticleSystem flameParticle; // Particle effect for flames

    private AudioSource audioSource;

    private void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Play destroy sound
        if (destroySound != null && audioSource != null)
        {
            audioSource.PlayOneShot(destroySound);
        }

        // Instantiate the prefab at the enemy's position and rotation
        Instantiate(DestroyedPrefab, transform.position, transform.rotation);

        // Play flame particle effect
        if (flameParticle != null)
        {
            Instantiate(flameParticle, transform.position, Quaternion.identity);
        }

        // Destroy the enemy game object
        Destroy(gameObject);
    }
}
