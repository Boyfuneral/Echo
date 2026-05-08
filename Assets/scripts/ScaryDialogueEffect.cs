using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering.Universal;
using Unity.Cinemachine;
using Unity.Cinemachine.Editor;

public class ScaryDialogueEffects : MonoBehaviour
{
    public Image flashImage;
    public float flashDuration = 2.5f;
    public float flashAlpha = 0.45f;
    public int flickerCount = 6;
    public float flickerSpeed = 0.08f;
    public Light[] lightsToFlicker;
    public AudioSource scarySound;
    public Camera mainCamera;
    public CinemachineImpulseSource impulseSource;

    public float shakeAmount = 0.08f;
    public float shakeTime = 0.3f;

    private Vector3 originalCameraPosition;

    void Start()
    {
        // Make sure flash starts invisible
        if (flashImage != null)
        {
            flashImage.color = new Color(1, 0, 0, 0);
        }
    }

    public void PlayScaryEffect()
    {

        if (scarySound != null  && !scarySound.isPlaying)
        {
            scarySound.Play();
        }

        // cinemachine camera shake
        if (impulseSource != null)
        {
            impulseSource.GenerateImpulse();
        }

        StartCoroutine(PulseFlash());
        //StartCoroutine(FlickerLights());
    }

    IEnumerator PulseFlash()
    {
        if (flashImage == null)
            yield break;

        float halfDuration = flashDuration / 2f;

        // FIRST PULSE
        yield return StartCoroutine(FadeFlash(0f, flashAlpha, halfDuration * 0.5f));
        yield return StartCoroutine(FadeFlash(flashAlpha, 0f, halfDuration * 0.5f));

        // SECOND PULSE
        yield return StartCoroutine(FadeFlash(0f, flashAlpha, halfDuration * 0.5f));
        yield return StartCoroutine(FadeFlash(flashAlpha, 0f, halfDuration * 0.5f));

        // Ensure invisible at end
        flashImage.color = new Color(1, 0, 0, 0);
    }

    IEnumerator FadeFlash(float startAlpha, float endAlpha, float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            float alpha = Mathf.Lerp(startAlpha, endAlpha, timer / duration);

            flashImage.color = new Color(1, 0, 0, alpha);

            yield return null;
        }

        flashImage.color = new Color(1, 0, 0, endAlpha);
    }
    //IEnumerator FlickerLights()
    //{
       // if (lightsToFlicker == null || lightsToFlicker.Length == 0)
       //     yield break;
//
       // for (int i = 0; i < flickerCount; i++)
       // {
       //     foreach (Light2D light in lightsToFlicker)
       //     {
       //         if (light != null)
       //         {
       //             light.enabled = !light.enabled;
       //         }
       //     }
//
       //     yield return new WaitForSeconds(flickerSpeed);
       // }
//
       // // Ensure lights end ON
       // foreach (Light2D light in lightsToFlicker)
       // {
       //     if (light != null)
       //     {
       //         light.enabled = true;
       //     }
       // }
    //}
}