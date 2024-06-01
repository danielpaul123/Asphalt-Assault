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
        // Play destroy sound from the destroyed instance
        GameObject destroyedInstance = Instantiate(DestroyedPrefab, transform.position, transform.rotation);
        if (destroySound != null && destroyedInstance != null)
        {
            AudioSource destroyedAudioSource = destroyedInstance.AddComponent<AudioSource>();
            destroyedAudioSource.clip = destroySound;
            destroyedAudioSource.Play();
        }

        // Instantiate and play flame particle effect from a separate game object
        if (flameParticle != null)
        {
            ParticleSystem flameInstance = Instantiate(flameParticle, transform.position, Quaternion.identity);
            flameInstance.Play();
            Destroy(flameInstance.gameObject, flameInstance.main.duration + flameInstance.main.startLifetime.constantMax);
        }

        // Destroy the enemy game object
        Destroy(gameObject);

        // Destroy the instantiated destroyed prefab after the sound has played
        if (destroyedInstance != null)
        {
            Destroy(destroyedInstance, destroySound.length);
        }
    }


}
