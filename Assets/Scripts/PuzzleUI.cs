using UnityEngine;
using TMPro;

public class PuzzleUI : MonoBehaviour
{
    public GameObject puzzleBox;
    public TextMeshProUGUI resultText;
    public GameObject barrierToUnlock;

    void Start()
    {
        if (puzzleBox != null)
            puzzleBox.SetActive(false);

        if (resultText != null)
            resultText.text = "";
    }

    public void OpenPuzzle()
    {
        if (puzzleBox != null)
            puzzleBox.SetActive(true);

        if (resultText != null)
            resultText.text = "";
    }

    public void ChooseCorrect()
    {
        if (resultText != null)
            resultText.text = "Correct. The path opens.";

        if (barrierToUnlock != null)
            barrierToUnlock.SetActive(false);
    }

    public void ChooseWrong()
    {
        if (resultText != null)
            resultText.text = "That does not belong here.";
    }

    public void ClosePuzzle()
    {
        if (puzzleBox != null)
            puzzleBox.SetActive(false);
    }
}