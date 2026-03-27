using UnityEngine;
using TMPro;
using System.Collections;

public class MirrorInteractable : Interactable
{
public TMP_Text mirrorText; // Drag your TextMeshPro object here
    public float fadeDuration = 1.5f; // How long the fade takes
    public float displayTime = 3f;    // How long it stays fully visible

    private bool isFading = false;

    void Start()
    {
        // Ensure the text starts completely invisible
        SetTextAlpha(0f);
    }

    public override void Interact()
    {
        // Prevent spam-clicking from restarting the animation
        if (!isFading)
        {
            StartCoroutine(FadeTextRoutine());
        }
    }

    IEnumerator FadeTextRoutine()
    {
        isFading = true;

        // Fade In
        yield return Fade(0f, 1f);

        // Wait for the player to read it
        yield return new WaitForSeconds(displayTime);

        // Fade Out
        yield return Fade(1f, 0f);

        isFading = false;
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        Color color = mirrorText.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            mirrorText.color = color;
            yield return null; // Wait for the next frame
        }

        // Lock exactly to the target alpha at the end
        color.a = endAlpha;
        mirrorText.color = color;
    }

    void SetTextAlpha(float alpha)
    {
        Color color = mirrorText.color;
        color.a = alpha;
        mirrorText.color = color;
    }
}
