using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Make sure to include this for UI components

public class GoBlack : MonoBehaviour
{
    public RawImage blackScreenImage; // Reference to the RawImage that covers the screen
    public float fadeDuration = 2f; // Duration for the fade effect

    void Start()
    {
        // Start the coroutine to make the image visible after a delay
        StartCoroutine(GoBlackCoroutine());
    }

    IEnumerator GoBlackCoroutine()
    {
        // Wait for 45 seconds
        yield return new WaitForSeconds(45f);

        // Make the black screen image visible
        blackScreenImage.enabled = true; // Enable the RawImage to show it

        // Start fading the black screen in
        yield return StartCoroutine(FadeToBlack());
    }

    IEnumerator FadeToBlack()
    {
        Color currentColor = blackScreenImage.color; // Get the current color
        currentColor.a = 0; // Ensure starting alpha is 0 (fully transparent)
        blackScreenImage.color = currentColor; // Set the initial color

        float elapsedTime = 0f; // Time tracker

        while (elapsedTime < fadeDuration)
        {
            // Calculate the new alpha value
            currentColor.a = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            blackScreenImage.color = currentColor; // Update the color

            elapsedTime += Time.deltaTime; // Increment elapsed time
            yield return null; // Wait for the next frame
        }

        // Ensure the final color is fully opaque
        currentColor.a = 1;
        blackScreenImage.color = currentColor;
    }
}