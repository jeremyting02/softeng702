using System.Collections;
using UnityEngine;

public class playmissile : MonoBehaviour
{
    public AudioClip missileSound; // Drag your MP3 file here in the Inspector
    private AudioSource audioSource;

    public float soundDelay = 43f;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Start the coroutine to play the sound after 5 seconds
        StartCoroutine(PlaySoundAfterDelay(soundDelay));
    }

    IEnumerator PlaySoundAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Play the audio clip
        audioSource.clip = missileSound; // Set the audio clip to the audio source
        audioSource.Play(); // Play the sound
    }
}