using UnityEngine;

[CreateAssetMenu(fileName = "RoomDialogue", menuName = "Scriptable Objects/RoomDialogue")]
public class RoomDialogue : ScriptableObject
{
    [TextArea] public string[] intro;
    [TextArea] public string[] hint;
    [TextArea] public string[] completion;
}
