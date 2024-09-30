using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmissilemove : MonoBehaviour
{
    public AudioClip missileSound; // Drag your MP3 file here in the Inspector
    private AudioSource audioSource;

    public float soundDelay = 43f; // Delay before starting the sound
    public float soundDuration = 5f; // Duration of the sound
    public float maxVolume = 1f; // Maximum volume

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Start the coroutine to play the sound after the delay
        StartCoroutine(PlaySoundAfterDelay(soundDelay));
    }

    IEnumerator PlaySoundAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Set the audio clip to the audio source
        audioSource.clip = missileSound;
        audioSource.volume = 0f; // Start volume at 0
        audioSource.Play(); // Play the sound

        // Gradually increase the volume over the specified duration
        float elapsedTime = 0f;

        while (elapsedTime < soundDuration)
        {
            // Calculate the new volume
            float newVolume = Mathf.Lerp(0f, maxVolume, elapsedTime / soundDuration);
            audioSource.volume = newVolume;

            // Increment elapsed time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the volume is set to max at the end
        audioSource.volume = maxVolume;
    }
}