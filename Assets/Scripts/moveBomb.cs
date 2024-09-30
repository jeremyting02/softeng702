using System.Collections;
using UnityEngine;

public class MoveBomb : MonoBehaviour
{
    public float invisibilityDuration = 5f; // Duration to keep the bomb particles invisible
    private ParticleSystem bombParticleSystem; // Reference to the ParticleSystem component

    void Start()
    {
        // Get the ParticleSystem component from the bomb GameObject
        bombParticleSystem = GetComponent<ParticleSystem>();

        // Start the invisibility coroutine
        StartCoroutine(InvisibilityCoroutine());
    }

    IEnumerator InvisibilityCoroutine()
    {
        // Stop the particle system to make it invisible
        bombParticleSystem.Stop(); // Stop the particles

        // Wait for the invisibility duration
        yield return new WaitForSeconds(invisibilityDuration);

        // Start the particle system again to make it visible
        bombParticleSystem.Play(); // Play the particles
    }
}