using UnityEngine;
using System.Collections;

public class PlayIntro : MonoBehaviour
{
    public AudioSource firstAudio;
    public AudioSource secondAudio;

    void Start()
    {
        StartCoroutine(PlayAudiosWithDelays());
    }

    IEnumerator PlayAudiosWithDelays()
    {
        // Wait for 1 second before playing the first audio clip
        yield return new WaitForSeconds(1.0f);

        if (firstAudio != null)
        {
            firstAudio.Play();
            
            // Wait until the first audio clip has finished playing
            while (firstAudio.isPlaying)
            {
                yield return null;
            }
        }

        yield return new WaitForSeconds(2.0f);

        // Play the second audio clip
        if (secondAudio != null)
        {
            secondAudio.Play();
        }
    }
}
