using System.Collections;
using UnityEngine;

public class MoveBomb : MonoBehaviour
{
    public float invisibilityDuration = 5f; 
    private ParticleSystem bombParticleSystem;

    void Start()
    {

        bombParticleSystem = GetComponent<ParticleSystem>();


        StartCoroutine(InvisibilityCoroutine());
    }

    IEnumerator InvisibilityCoroutine()
    {

        bombParticleSystem.Stop(); 


        yield return new WaitForSeconds(invisibilityDuration);


        bombParticleSystem.Play(); 
    }
}