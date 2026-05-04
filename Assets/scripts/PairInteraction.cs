using UnityEngine;

public class PairInteraction : MonoBehaviour
{
    public int pairNumber;
    public bool isFaultyPair;
    public bool isLeftSide;

    public Room3PuzzleManager puzzleManager;

    public Sprite clueSprite;
    public InspectionManager inspectionManager;

    private void OnMouseDown()
    {
        if (puzzleManager == null)
        {
            Debug.LogError(gameObject.name + " is missing PuzzleManager.");
            return;
        }

        if (puzzleManager.IsPanelUnlocked())
        {
            if (inspectionManager != null && clueSprite != null)
            {
                inspectionManager.ShowInspection(clueSprite);
            }
            else
            {
                Debug.Log(gameObject.name + " has no inspection clue assigned.");
            }

            return;
        }

        puzzleManager.CheckObservationPair(pairNumber, isFaultyPair, isLeftSide);
    }
}