using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScaryDialogueEffects : MonoBehaviour
{
    public Image flashImage;
    public Light[] lightsToFlicker;
    public AudioSource scarySound;
    public Camera mainCamera;

    public float shakeAmount = 0.08f;
    public float shakeTime = 0.3f;

    private Vector3 originalCameraPosition;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (mainCamera != null)
            originalCameraPosition = mainCamera.transform.position;

        if (flashImage != null)
            flashImage.color = new Color(1, 0, 0, 0);
    }

    public void PlayScaryEffect()
    {
        StartCoroutine(ScaryEffectRoutine());
    }

    IEnumerator ScaryEffectRoutine()
    {
        if (scarySound != null)
            scarySound.Play();

        StartCoroutine(ScreenFlash());
        StartCoroutine(CameraShake());
        StartCoroutine(FlickerLights());

        yield return null;
    }

    IEnumerator ScreenFlash()
    {
        if (flashImage == null)
            yield break;

        flashImage.color = new Color(1, 0, 0, 0.45f);

        yield return new WaitForSeconds(0.12f);

        flashImage.color = new Color(1, 0, 0, 0);
    }

    IEnumerator CameraShake()
    {
        if (mainCamera == null)
            yield break;

        float timer = 0f;

        while (timer < shakeTime)
        {
            float x = Random.Range(-shakeAmount, shakeAmount);
            float y = Random.Range(-shakeAmount, shakeAmount);

            mainCamera.transform.position = originalCameraPosition + new Vector3(x, y, 0);

            timer += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = originalCameraPosition;
    }

    IEnumerator FlickerLights()
    {
        if (lightsToFlicker == null)
            yield break;

        for (int i = 0; i < 6; i++)
        {
            foreach (Light light in lightsToFlicker)
            {
                if (light != null)
                    light.enabled = !light.enabled;
            }

            yield return new WaitForSeconds(0.08f);
        }

        foreach (Light light in lightsToFlicker)
        {
            if (light != null)
                light.enabled = true;
        }
    }
}