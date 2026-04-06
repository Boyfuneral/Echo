using UnityEngine;
using TMPro;

public class PuzzleUI : MonoBehaviour
{
    [Header("Main Puzzle Box")]
    public GameObject puzzleBox;
    public TextMeshProUGUI resultText;
    public GameObject barrierToUnlock;

    [Header("Old Choice Buttons")]
    public GameObject choiceButtonGroup;   // Tree / Vine / Clock buttons group

    [Header("Word Puzzle UI")]
    public GameObject wordPuzzleGroup;     // parent object for word puzzle UI
    public TextMeshProUGUI puzzleWordText;
    public TMP_InputField answerInput;

    private string correctAnswer = "TIME";
    private string backwardWord = "EMIT";

    void Start()
    {
        if (puzzleBox != null)
            puzzleBox.SetActive(false);

        if (resultText != null)
            resultText.text = "";

        if (wordPuzzleGroup != null)
            wordPuzzleGroup.SetActive(false);
    }

    public void OpenPuzzle()
    {
        if (puzzleBox != null)
            puzzleBox.SetActive(true);

        if (resultText != null)
            resultText.text = "";

        if (choiceButtonGroup != null)
            choiceButtonGroup.SetActive(true);

        if (wordPuzzleGroup != null)
            wordPuzzleGroup.SetActive(false);
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

    public void OpenClockWordPuzzle()
    {
        if (resultText != null)
            resultText.text = "";

        if (choiceButtonGroup != null)
            choiceButtonGroup.SetActive(false);

        if (wordPuzzleGroup != null)
            wordPuzzleGroup.SetActive(true);

        if (puzzleWordText != null)
            puzzleWordText.text = backwardWord;

        if (answerInput != null)
        {
            answerInput.text = "";
            answerInput.ActivateInputField();
        }
    }

    public void CheckWordAnswer()
    {
        if (answerInput == null) return;

        string playerAnswer = answerInput.text.Trim().ToUpper();

        if (playerAnswer == correctAnswer)
        {
            if (resultText != null)
                resultText.text = "Correct. The clock has been restored.";

            if (barrierToUnlock != null)
                barrierToUnlock.SetActive(false);

            Invoke(nameof(ClosePuzzle), 1.5f);
        }
        else
        {
            if (resultText != null)
                resultText.text = "That is not correct.";
        }
    }

    public void ClosePuzzle()
    {
        if (puzzleBox != null)
            puzzleBox.SetActive(false);

        if (choiceButtonGroup != null)
            choiceButtonGroup.SetActive(true);

        if (wordPuzzleGroup != null)
            wordPuzzleGroup.SetActive(false);
    }
}