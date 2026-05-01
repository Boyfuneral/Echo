using UnityEngine;
using TMPro;

public class PuzzleUI : MonoBehaviour
{
    [Header("Main Puzzle Box")]
    public GameObject puzzleBox;
    public TextMeshProUGUI resultText;
    public GameObject barrierToUnlock;

    [Header("Old Choice Buttons")]
    public GameObject choiceButtonGroup;

    [Header("Word Puzzle UI")]
    public GameObject wordPuzzleGroup;
    public TextMeshProUGUI puzzleWordText;
    public TMP_InputField answerInput;
    public TextMeshProUGUI puzzleQuestionText;

    private int puzzleStage = 0;

    void Start()
    {
        if (puzzleBox != null)
            puzzleBox.SetActive(false);

        if (resultText != null)
            resultText.text = "";

        if (wordPuzzleGroup != null)
            wordPuzzleGroup.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (puzzleBox != null && puzzleBox.activeSelf)
            {
                CheckWordAnswer();
            }
        }
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

        if (puzzleQuestionText != null)
            puzzleQuestionText.text = "Something about time is reversed.";

        if (puzzleWordText != null)
            puzzleWordText.text = "EMIT";

        if (answerInput != null)
        {
            answerInput.text = "";
            answerInput.ActivateInputField();
        }

        puzzleStage = 0;
    }

    public void CheckWordAnswer()
{
    if (answerInput == null) return;

    string playerAnswer = answerInput.text.Trim().ToUpper();

    // Stage 0: EMIT -> TIME
    if (puzzleStage == 0 && playerAnswer == "TIME")
    {
        puzzleStage = 1;

        if (puzzleQuestionText != null)
            puzzleQuestionText.text = "Time moves in cycles...";

        if (puzzleWordText != null)
            puzzleWordText.text = "3 → 6 → 9 → ?";

        if (resultText != null)
            resultText.text = "";

        answerInput.text = "";
        answerInput.ActivateInputField();
        return;
    }

    // Stage 1: cycle answer
    if (puzzleStage == 1 && playerAnswer == "12")
    {
        puzzleStage = 2;

        if (puzzleQuestionText != null)
            puzzleQuestionText.text = "Where does the cycle begin?";

        if (puzzleWordText != null)
            puzzleWordText.text = "Enter the frozen hour.";

        if (resultText != null)
            resultText.text = "";

        answerInput.text = "";
        answerInput.ActivateInputField();
        return;
    }

   
    if (puzzleStage == 2 && playerAnswer == "3")
    {
        if (resultText != null)
            resultText.text = "The barrier yields.";

        if (barrierToUnlock != null)
            barrierToUnlock.SetActive(false);

        Invoke(nameof(ClosePuzzle), 1.5f);
        return;
    }

    if (resultText != null)
        resultText.text = "That is not correct.";
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