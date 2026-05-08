using UnityEngine;
using System.Collections;

public class fasingbg : MonoBehaviour
{
    [Header("Sprite")]
    public SpriteRenderer sr;

    [Header("Alpha Range")]
    [Range(0f, 1f)] public float minAlpha = 0.25f;
    [Range(0f, 1f)] public float maxAlpha = 1f;

    [Header("Speed")]
    public float fadeSpeed = 1f;

    void Awake()
    {
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();

        StartCoroutine(BreathingEffect());
    }

    IEnumerator BreathingEffect()
    {
        while (true)
        {
            // Fade In
            yield return FadeAlpha(minAlpha, maxAlpha);

            // Fade Out
            yield return FadeAlpha(maxAlpha, minAlpha);
        }
    }

    IEnumerator FadeAlpha(float start, float end)
    {
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * fadeSpeed;

            float alpha = Mathf.Lerp(start, end, time);

            Color color = sr.color;
            color.a = alpha;
            sr.color = color;

            yield return null;
        }

        // Ensure exact final value
        Color finalColor = sr.color;
        finalColor.a = end;
        sr.color = finalColor;
    }
}
