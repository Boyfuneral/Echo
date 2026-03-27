using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public GameObject puzzleOverlay;
    public MoveScript player;
    public bool isPuzzleActive = false;

    void Awake()
    {
        Instance = this;
        puzzleOverlay.SetActive(false);
    }

    public void StartPuzzle(GameObject puzzleUI)
    {
        isPuzzleActive = true;
        puzzleOverlay.SetActive(true);
        puzzleUI.SetActive(true);

        player.canMove = false;
        //Cursor.visible = true;
    }

    public void EndPuzzle(GameObject puzzleUI)
    {
        isPuzzleActive = false;
        puzzleUI.SetActive(false);
        puzzleOverlay.SetActive(false);

        player.canMove = true;
        //Cursor.visible = false;
        
    }
}
