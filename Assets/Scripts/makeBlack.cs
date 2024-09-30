using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Include this for UI components

public class MakeBlack : MonoBehaviour
{
    public RawImage blackScreenImage; // Reference to the RawImage that covers the screen
    public float fadeDuration = 2f; // Duration of the fade to black
    public float delay = 45f; 

    void Start()
    {
        // Start the coroutine to fade to black after a delay
        StartCoroutine(FadeToBlackCoroutine());
    }

    IEnumerator FadeToBlackCoroutine()
    {
        // Wait for 2 seconds before starting the fade
        yield return new WaitForSeconds(delay);

        // Gradually change the color of the RawImage to black over the specified duration
        float elapsedTime = 0f;
        Color startColor = blackScreenImage.color; // Get the initial color
        Color targetColor = new Color(0, 0, 0, 1); // Target color is black with full opacity

        while (elapsedTime < fadeDuration)
        {
            // Calculate the progress of the fade
            float t = elapsedTime / fadeDuration;

            // Lerp the color from the start color to the target color
            blackScreenImage.color = Color.Lerp(startColor, targetColor, t);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the color is set to the target color at the end
        blackScreenImage.color = targetColor;
    }
}