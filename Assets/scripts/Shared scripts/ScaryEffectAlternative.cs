using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScaryEffectAlternative : MonoBehaviour
{

    public Image flashImage;

    public float flashDuration = 2.5f;

    [Range(0f, 1f)]
    public float flashAlpha = 0.45f;

    [Header("Camera Shake")]
    public Camera mainCamera;

    public float shakeAmount = 0.15f;
    public float shakeDuration = 0.35f;

    private Vector3 originalCameraPosition;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip scaryClip;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (mainCamera != null)
        {
            originalCameraPosition = mainCamera.transform.position;
        }

        // Start flash invisible
        if (flashImage != null)
        {
            flashImage.color = new Color(1, 0, 0, 0);
        }
    }

    public void PlayScaryEffect()
    {
        // Play short horror sting
        if (audioSource != null && scaryClip != null)
        {
            audioSource.PlayOneShot(scaryClip);
        }

        StartCoroutine(PulseFlash());
        StartCoroutine(CameraShake());
    }

    IEnumerator PulseFlash()
    {
        if (flashImage == null)
            yield break;

        float halfDuration = flashDuration / 2f;

        // First pulse
        yield return StartCoroutine(
            FadeFlash(0f, flashAlpha, halfDuration * 0.5f)
        );

        yield return StartCoroutine(
            FadeFlash(flashAlpha, 0f, halfDuration * 0.5f)
        );

        // Second pulse
        yield return StartCoroutine(
            FadeFlash(0f, flashAlpha, halfDuration * 0.5f)
        );

        yield return StartCoroutine(
            FadeFlash(flashAlpha, 0f, halfDuration * 0.5f)
        );

        // Ensure invisible
        flashImage.color = new Color(1, 0, 0, 0);
    }

    IEnumerator FadeFlash(float startAlpha, float endAlpha, float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            float alpha = Mathf.Lerp(
                startAlpha,
                endAlpha,
                timer / duration
            );

            flashImage.color = new Color(1, 0, 0, alpha);

            yield return null;
        }

        flashImage.color = new Color(1, 0, 0, endAlpha);
    }

    IEnumerator CameraShake()
    {
        if (mainCamera == null)
            yield break;

        float timer = 0f;

        while (timer < shakeDuration)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-shakeAmount, shakeAmount),
                Random.Range(-shakeAmount, shakeAmount),
                0f
            );

            mainCamera.transform.position =
                originalCameraPosition + randomOffset;

            timer += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.position = originalCameraPosition;
    }
}
