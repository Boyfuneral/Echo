using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public LightPuzzleManager puzzleManager;
    public PuzzleLight puzzleLight;

    private bool canTrigger = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canTrigger && other.CompareTag("Player"))
        {
            canTrigger = false;
            Debug.Log("TOUCHED LIGHT: " + puzzleLight.lightIndex);
            puzzleManager.PlayerPressedLight(puzzleLight.lightIndex);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTrigger = true;
        }
    }
}