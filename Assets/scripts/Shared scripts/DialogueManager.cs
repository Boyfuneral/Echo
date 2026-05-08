using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    public float textSpeed = 0.03f;

    private Queue<string> lines = new Queue<string>();

    private bool isTyping = false;
    private bool dialogueActive = false;

    private string currentLine;

    public System.Action onDialogueFinished;

    private float inputBlockTimer = 0f;

    public bool IsDialogueActive => dialogueActive;
    public MoveScript playerMovement;

    public float autoAdvanceDelay = 2f;

    private Coroutine typingCoroutine;

    void Awake()
    {
        Instance = this;
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(string[] dialogueLines)
    {
        if (dialogueLines == null || dialogueLines.Length == 0)
            return;

        //playerMovement.canMove = false;

        dialoguePanel.SetActive(true);
        dialogueActive = true;

        inputBlockTimer = 0.1f;

        lines.Clear();

        foreach (string line in dialogueLines)
        {
            lines.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        currentLine = lines.Dequeue();

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeLine(currentLine));
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;

        yield return new WaitForSeconds(autoAdvanceDelay);

        DisplayNextLine();
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialoguePanel.SetActive(false);

        onDialogueFinished?.Invoke();
        //playerMovement.canMove = true;
    }

    void Update()
    {
        if (!dialogueActive)
            return;

        if (inputBlockTimer > 0f)
        {
            inputBlockTimer -= Time.deltaTime;
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // ONLY skip current typing animation
            if (isTyping)
            {
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                }

                dialogueText.text = currentLine;

                isTyping = false;

                StartCoroutine(AutoContinueAfterSkip());
            }
        }
    }

    IEnumerator AutoContinueAfterSkip()
    {
        yield return new WaitForSeconds(autoAdvanceDelay);

        DisplayNextLine();
    }

}
