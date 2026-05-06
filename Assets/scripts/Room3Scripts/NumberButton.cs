using UnityEngine;

public class NumberButton : MonoBehaviour
{
    public int numberValue;
    public Room3SequenceInput sequenceManager;

    private void OnMouseDown()
    {
        if (sequenceManager != null)
        {
            sequenceManager.PressNumber(numberValue);
        }
    }
}
