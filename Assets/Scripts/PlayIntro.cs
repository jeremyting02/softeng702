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

        yield return new WaitForSeconds(1.0f);

        if (firstAudio != null)
        {
            firstAudio.Play();
            

            while (firstAudio.isPlaying)
            {
                yield return null;
            }
        }

        yield return new WaitForSeconds(2.0f);


        if (secondAudio != null)
        {
            secondAudio.Play();
        }
    }
}
