using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string fullText;
    public float typingSpeed = 0.05f;
    public float displayTime = 2f;
    public CanvasGroup canvasGroup;

    void Start()
    {
        textComponent.text = "";
    }

    public void StartTyping(string newText)
    {
        StopAllCoroutines();
        fullText = newText;
        textComponent.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(displayTime);

        // Fade out
        if (canvasGroup != null)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime;
                yield return null;
            }
        }
    }
}