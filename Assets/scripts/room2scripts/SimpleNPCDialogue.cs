using UnityEngine;
using TMPro;

public class SimpleNPCDialogue : MonoBehaviour
{
    public GameObject pressEText;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;

    [TextArea(3, 6)]
    public string message = "This forest follows rules. Learn them, and you can move forward.";

    private bool playerNearby = false;
    private bool dialogueOpen = false;

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
            dialogueOpen = !dialogueOpen;

            if (dialogueBox != null)
                dialogueBox.SetActive(dialogueOpen);

            if (pressEText != null)
                pressEText.SetActive(!dialogueOpen);

            if (dialogueText != null)
                dialogueText.text = message;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;

            if (pressEText != null && !dialogueOpen)
                pressEText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
            dialogueOpen = false;

            if (pressEText != null)
                pressEText.SetActive(false);

            if (dialogueBox != null)
                dialogueBox.SetActive(false);
        }
    }
}