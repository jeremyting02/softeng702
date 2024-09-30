using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MakeBlack : MonoBehaviour
{
    public RawImage blackScreenImage;
    public float fadeDuration = 2f;
    public float delay = 45f;

    void Start()
    {

        StartCoroutine(FadeToBlackCoroutine());
    }

    IEnumerator FadeToBlackCoroutine()
    {

        yield return new WaitForSeconds(delay);


        float elapsedTime = 0f;
        Color startColor = blackScreenImage.color;
        Color targetColor = new Color(0, 0, 0, 1);

        while (elapsedTime < fadeDuration)
        {

            float t = elapsedTime / fadeDuration;


            blackScreenImage.color = Color.Lerp(startColor, targetColor, t);


            elapsedTime += Time.deltaTime;
            yield return null;
        }


        blackScreenImage.color = targetColor;
    }
}