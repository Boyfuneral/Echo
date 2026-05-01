using UnityEngine;
using TMPro;

public class IntroText : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    void Start()
    {
        StartCoroutine(FadeText());
    }

    System.Collections.IEnumerator FadeText()
    {
        // Fade in
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(6f);

        // Fade out
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime;
            yield return null;
        }
    }
}