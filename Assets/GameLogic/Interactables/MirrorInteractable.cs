using UnityEngine;
using TMPro;
using System.Collections;

public class MirrorInteractable : Interactable
{
public TMP_Text mirrorText; 
    public float fadeDuration = 1.5f; 
    public float displayTime = 3f;    

    private bool isFading = false;

    void Start()
    {
        SetTextAlpha(0f);
    }

    public override void Interact()
    {
        if (!isFading)
        {
            StartCoroutine(FadeTextRoutine());
        }
    }

    IEnumerator FadeTextRoutine()
    {
        isFading = true;


        yield return Fade(0f, 1f);
        yield return new WaitForSeconds(displayTime);
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
            yield return null;
        }

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
