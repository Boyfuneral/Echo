using UnityEngine;

public class StrapInteract : Interactable
{
    public GameObject puzzleUI;

    [Header("Visuals")]
    public SpriteRenderer objectSpriteRenderer;
    public Sprite freedSprite;

    [Header("Player Reveal")]
    public SpriteRenderer playerSpriteRenderer;

    public override void Interact()
    {
        PuzzleManager.Instance.StartPuzzle(puzzleUI);
    }

    public void RevealPlayer()
    {

        objectSpriteRenderer.sprite = freedSprite;

        Color color = playerSpriteRenderer.color;
        color.a = 1f;
        playerSpriteRenderer.color = color;
    }

}
