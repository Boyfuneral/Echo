using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public GameObject puzzleOverlay;
    public MoveScript player;
    public bool isPuzzleActive = false;
    public GameObject currentPuzzleUI;

    void Awake()
    {
        Instance = this;
        puzzleOverlay.SetActive(false);
    }

    public void StartPuzzle(GameObject puzzleUI)
    {
        isPuzzleActive = true;

        currentPuzzleUI = puzzleUI;

        puzzleOverlay.SetActive(true);
        puzzleUI.SetActive(true);

        //player.canMove = false;
    }

    public void EndPuzzle()
    {
        if (currentPuzzleUI != null)
        {
            currentPuzzleUI.SetActive(false);
        }
    
        isPuzzleActive = false;
        puzzleOverlay.SetActive(false);
    
        //player.canMove = true;
    
        currentPuzzleUI = null;
    }
}
