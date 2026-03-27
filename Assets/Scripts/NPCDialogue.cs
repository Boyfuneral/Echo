using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public GameObject pressEText;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public PuzzleUI puzzleUI;

    [TextArea(3, 6)]
    public string message = "This forest follows rules.\nNow solve the puzzle.";

    private bool playerNearby = false;
    private bool dialogueOpen = false;
    private bool puzzleOpened = false;

    void Start()
    {
        if (pressEText != null)
            pressEText.SetActive(false);

        if (dialogueBox != null)
            dialogueBox.SetActive(false);
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

                if (dialogueText != null)
                    dialogueText.text = message;
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