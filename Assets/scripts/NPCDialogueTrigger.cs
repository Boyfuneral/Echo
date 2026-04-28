using System.Collections;
using UnityEngine;
using TMPro;

public class NPCDialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public LightPuzzleManager puzzleManager;

    private TypewriterText typewriter;
    private bool playerInRange = false;
    private bool started = false;

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
                StartCoroutine(DialogueThenStartPuzzle());
            }
        }
    }

    IEnumerator DialogueThenStartPuzzle()
    {
        if (dialogueBox != null)
            dialogueBox.SetActive(true);

        string message = "The lights will guide you... if you fail, you will not return.";

        if (typewriter != null)
            typewriter.StartTyping(message);
        else if (dialogueText != null)
            dialogueText.text = message;

        yield return new WaitForSeconds(3f);

        if (dialogueBox != null)
            dialogueBox.SetActive(false);

        if (puzzleManager != null)
            puzzleManager.StartPuzzle();
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