using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float typingSpeed = 0.05f;

    private Coroutine typingCoroutine;

    void Awake()
    {
        if (textComponent == null)
            textComponent = GetComponent<TextMeshProUGUI>();

        textComponent.text = "";
    }

    public void StartTyping(string newText)
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(newText));
    }

    IEnumerator TypeText(string newText)
    {
        textComponent.text = "";

        foreach (char letter in newText)
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}