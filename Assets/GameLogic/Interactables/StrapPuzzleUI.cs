//using System.Diagnostics;
using UnityEngine;

public class StrapPuzzleUI : MonoBehaviour
{
    int[] correctOrder = { 4, 1, 3, 2 };
    int currentIndex = 0;
    public RoomController roomController;
    private int resetCount = 0;
    public int hintThreshold = 3;
    public GameObject interactableObject;
    public MoveScript playerMovement;
    public MirrorInteractable mirrorInteract;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PuzzleManager.Instance.EndPuzzle();
        }
    }
    public void RegisterInput(int id)
    {
        if (id == correctOrder[currentIndex])
        {
            currentIndex++;

            if (currentIndex >= correctOrder.Length)
            {
                PuzzleSolved();
            }
        }
        else
        {
            ResetPuzzle();
        }
    }

    void PuzzleSolved()
    {
        Debug.Log("Puzzle solved");
        playerMovement.isTrapped = false;
        playerMovement.rb.gravityScale = 1;
        gameObject.SetActive(false);
        PuzzleManager.Instance.EndPuzzle();
        roomController.CompleteRoom();
        interactableObject.GetComponent<Collider2D>().enabled = false;
        mirrorInteract.GetComponent<Collider2D>().enabled = false;

    }

    void ResetPuzzle()
    {
        resetCount++;

        if(resetCount >= hintThreshold)
        {
            roomController.GiveHint();
            resetCount = 0;
        }

        currentIndex = 0;
        Debug.Log("Wrong puzzle reset");
        gameObject.SetActive(false);
        PuzzleManager.Instance.EndPuzzle();
    }
}
