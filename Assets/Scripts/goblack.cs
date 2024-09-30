using System.Collections;
using UnityEngine;
using UnityEngine.UI; 

public class GoBlack : MonoBehaviour
{
    public RawImage blackScreenImage; 
    public float fadeDuration = 2f; 

    void Start()
    {

        StartCoroutine(GoBlackCoroutine());
    }

    IEnumerator GoBlackCoroutine()
    {

        yield return new WaitForSeconds(45f);


        blackScreenImage.enabled = true; 


        yield return StartCoroutine(FadeToBlack());
    }

    IEnumerator FadeToBlack()
    {
        Color currentColor = blackScreenImage.color; 
        currentColor.a = 0; 
        blackScreenImage.color = currentColor; 

        float elapsedTime = 0f; 

        while (elapsedTime < fadeDuration)
        {

            currentColor.a = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            blackScreenImage.color = currentColor; 

            elapsedTime += Time.deltaTime; 
            yield return null; 
        }

        currentColor.a = 1;
        blackScreenImage.color = currentColor;
    }
}