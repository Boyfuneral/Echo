using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
public Image fadeImage;
    public float fadeSpeed = 0.5f; 
    public float delay = 1f;
    public UnityEvent onFadeComplete;

    void Start()
    {

        Color startColor = fadeImage.color;
        startColor.a = 1f;
        fadeImage.color = startColor;

        StartCoroutine(FadeFromBlack());
    }

    IEnumerator FadeFromBlack()
    {

        yield return new WaitForSeconds(delay); 

        Color fadeColor = fadeImage.color;

        while (fadeColor.a > 0f)
        {

            fadeColor.a -= Time.deltaTime * fadeSpeed;
            fadeImage.color = fadeColor;
            
            yield return null; 
        }


        fadeImage.gameObject.SetActive(false);
        onFadeComplete?.Invoke();
    }
}