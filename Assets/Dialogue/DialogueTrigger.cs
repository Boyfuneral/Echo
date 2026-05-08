using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueSequence dialogueSequence;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered)
            return;

        if (!other.CompareTag("Player"))
            return;

        if (DialogueManager.Instance.IsDialogueActive)
            return;

        triggered = true;

        DialogueManager.Instance.StartDialogue(dialogueSequence.dialogueLines);
    }
}
