using UnityEngine;

public class ChestInteract : Interactable
{
    public GameObject puzzleUI;


    public override void Interact()
    {
        PuzzleManager.Instance.StartPuzzle(puzzleUI);
    }

}
