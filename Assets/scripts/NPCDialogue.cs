using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public ScaryDialogueEffects scaryEffects;
    public GameObject pressEText;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public PuzzleUI puzzleUI;

    [TextArea(3, 6)]
    public string message = "This forest follows rules...\nDisobey them, and it will remember you.";

    private bool playerNearby = false;
    private bool dialogueOpen = false;
    private bool puzzleOpened = false;

    private TypewriterText typewriter;

    void Start()
    {
        if (pressEText != null)
            pressEText.SetActive(false);

        if (dialogueBox != null)
            dialogueBox.SetActive(false);

        if (dialogueText != null)
            typewriter = dialogueText.GetComponent<TypewriterText>();
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueOpen)
            {
                dialogueOpen = true;

                if (pressEText != null)
                    pressEText.SetActive(false);

                if (dialogueBox != null)
                    dialogueBox.SetActive(true);

                if (scaryEffects != null)
                    scaryEffects.PlayScaryEffect();

                if (dialogueText != null)
                {
                    if (typewriter != null)
                        typewriter.StartTyping(message);
                    else
                        dialogueText.text = message;
                }
            }
            else if (!puzzleOpened)
            {
                puzzleOpened = true;

                if (dialogueBox != null)
                    dialogueBox.SetActive(false);

                if (puzzleUI != null)
                    puzzleUI.OpenPuzzle();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;

            if (!dialogueOpen && pressEText != null)
                pressEText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
            dialogueOpen = false;
            puzzleOpened = false;

            if (pressEText != null)
                pressEText.SetActive(false);

            if (dialogueBox != null)
                dialogueBox.SetActive(false);

            if (puzzleUI != null && puzzleUI.puzzleBox != null)
                puzzleUI.puzzleBox.SetActive(false);
        }
    }
}