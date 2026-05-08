using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TransitionOutOfScene : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 0.5f;
    public UnityEvent onFadeComplete;

    private bool isFading = false;

    void Awake()
    {
        // Ensure starting transparent
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;
    }

    public void StartFade()
    {
        if (!isFading)
        {
            StartCoroutine(FadeToBlackRoutine());
        }
    }

    IEnumerator FadeToBlackRoutine()
    {
        isFading = true;

        Color fadeColor = fadeImage.color;

        while (fadeColor.a < 1f)
        {
            fadeColor.a += Time.deltaTime * fadeSpeed;
            fadeImage.color = fadeColor;

            yield return null;
        }

        fadeColor.a = 1f;
        fadeImage.color = fadeColor;

        onFadeComplete?.Invoke();
    }
}
