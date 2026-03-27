using UnityEngine;

public class StrapInteract : Interactable
{
    public GameObject puzzleUI;


    public override void Interact()
    {
        PuzzleManager.Instance.StartPuzzle(puzzleUI);
    }

}
