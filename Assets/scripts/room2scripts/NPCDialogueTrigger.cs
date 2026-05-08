using System.Collections;
using UnityEngine;
using TMPro;

public class NPCDialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;

    private TypewriterText typewriter;
    private bool playerInRange = false;
    private bool started = false;
    public ScaryDialogueEffects scaryEffects;

    void Start()
    {
        if (dialogueBox != null)
            dialogueBox.SetActive(false);

        if (dialogueText != null)
            typewriter = dialogueText.GetComponent<TypewriterText>();
    }

    void Update()
    {
        if (playerInRange && !started)
        {
            if (dialogueBox != null)
                dialogueBox.SetActive(true);

            if (dialogueText != null)
                dialogueText.text = "Press E to Speak";

            if (Input.GetKeyDown(KeyCode.E))
            {
                started = true;
                StartCoroutine(ShowDialogue());
                scaryEffects.PlayScaryEffect();
            }
        }
    }

    IEnumerator ShowDialogue()
    {
        string message = "The lights will guide you...\nFind where they begin.";

        if (typewriter != null)
            typewriter.StartTyping(message);
        else if (dialogueText != null)
            dialogueText.text = message;

        yield return new WaitForSeconds(3f);

        if (dialogueBox != null)
            dialogueBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (dialogueBox != null)
                dialogueBox.SetActive(false);
        }
    }
}