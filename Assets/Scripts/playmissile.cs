using System.Collections;
using UnityEngine;

public class playmissile : MonoBehaviour
{
    public AudioClip missileSound; 
    private AudioSource audioSource;

    public float soundDelay = 43f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();


        StartCoroutine(PlaySoundAfterDelay(soundDelay));
    }

    IEnumerator PlaySoundAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);


        audioSource.clip = missileSound; 
        audioSource.Play(); 
    }
}