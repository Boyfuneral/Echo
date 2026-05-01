using UnityEngine;
using TMPro;

public class LightPuzzleStartPrompt : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public LightPuzzleManager puzzleManager;

    private bool started = false;

    void Start()
    {
        if (dialogueBox != null)
            dialogueBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (started) return;

        if (other.CompareTag("Player"))
        {
            started = true;

            if (dialogueBox != null && dialogueText != null)
            {
                dialogueBox.SetActive(true);
                dialogueText.text = "The lights have chosen you.";
            }

            if (puzzleManager != null)
                puzzleManager.StartPuzzle();
        }
    }
}