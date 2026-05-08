using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSequence", menuName = "Scriptable Objects/DialogueSequence")]
public class DialogueSequence : ScriptableObject
{
    [TextArea(3, 6)]
    public string[] dialogueLines;
}
