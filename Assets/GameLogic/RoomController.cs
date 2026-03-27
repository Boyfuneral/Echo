using UnityEngine;

public class RoomController : MonoBehaviour
{
    public RoomDialogue dialogue;

    private bool introPlayed = false;
    private bool roomCompleted = false;

    public void EnterRoom()
    {
        if (introPlayed) return;

        introPlayed = true;
        DialogueManager.Instance.StartDialogue(dialogue.intro);
    }

    public void GiveHint()
    {
        if (roomCompleted) return;

        DialogueManager.Instance.StartDialogue(dialogue.hint);
    }

    public void CompleteRoom()
    {
        if (roomCompleted) return;

        roomCompleted = true;
        DialogueManager.Instance.StartDialogue(dialogue.completion);
    }
}
