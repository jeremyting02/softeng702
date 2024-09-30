using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmissilemove : MonoBehaviour
{
    public AudioClip missileSound;
    private AudioSource audioSource;

    public float soundDelay = 43f; 
    public float soundDuration = 5f; 
    public float maxVolume = 1f; 

    void Start()
    {

        audioSource = GetComponent<AudioSource>();


        StartCoroutine(PlaySoundAfterDelay(soundDelay));
    }

    IEnumerator PlaySoundAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);


        audioSource.clip = missileSound;
        audioSource.volume = 0f; 
        audioSource.Play(); 


        float elapsedTime = 0f;

        while (elapsedTime < soundDuration)
        {

            float newVolume = Mathf.Lerp(0f, maxVolume, elapsedTime / soundDuration);
            audioSource.volume = newVolume;


            elapsedTime += Time.deltaTime;
            yield return null; 
        }


        audioSource.volume = maxVolume;
    }
}