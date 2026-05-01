using UnityEngine;

public class LightPuzzleSensor : MonoBehaviour
{
    public LightPuzzleManager lightPuzzleManager;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !triggered)
        {
            triggered = true;

            if (lightPuzzleManager != null)
                lightPuzzleManager.OpenPuzzle(); 
        }
    }
}