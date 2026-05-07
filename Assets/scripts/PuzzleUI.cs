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
    public ScaryDialogueEffects scaryEffects;

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
            if (puzzleBox != null && puzzleBox.activeSelf && wordPuzzleGroup != null && wordPuzzleGroup.activeSelf)
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

    // Make your correct button call this
    public void ChooseCorrect()
    {
        OpenClockWordPuzzle();
    }

    public void ChooseWrong()
    {
        scaryEffects.PlayScaryEffect();
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
            puzzleQuestionText.text = "I have a face but no eyes. I have hands but no skin. I count what you cannot hold.";

        if (puzzleWordText != null)
            puzzleWordText.text = "What am I?";

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

        // Answer: CLOCK
        if (puzzleStage == 0 && playerAnswer == "CLOCK")
        {
            puzzleStage = 1;

            if (puzzleQuestionText != null)
                puzzleQuestionText.text = "I always return to where I started. I repeat without ending.";

            if (puzzleWordText != null)
                puzzleWordText.text = "What am I?";

            if (resultText != null)
                resultText.text = "The barrier hums softly...";

            answerInput.text = "";
            answerInput.ActivateInputField();
            return;
        }

        // Answer: CYCLE
        if (puzzleStage == 1 && playerAnswer == "CYCLE")
        {
            puzzleStage = 2;

            if (puzzleQuestionText != null)
                puzzleQuestionText.text = "On a clock, the cycle completes after 3, 6, and 9. What number closes the loop?";

            if (puzzleWordText != null)
                puzzleWordText.text = "3 → 6 → 9 → ?";

            if (resultText != null)
                resultText.text = "The room grows still...";

            answerInput.text = "";
            answerInput.ActivateInputField();
            return;
        }

        // Answer: 12
        if (puzzleStage == 2 && playerAnswer == "12")
        {
            puzzleStage = 3;

            if (puzzleQuestionText != null)
                puzzleQuestionText.text = "I move forward, yet I cannot be seen. I control clocks, cycles, and the locked path.";

            if (puzzleWordText != null)
                puzzleWordText.text = "What am I?";

            if (resultText != null)
                resultText.text = "The barrier weakens...";

            answerInput.text = "";
            answerInput.ActivateInputField();
            return;
        }

        // Answer: TIME
        if (puzzleStage == 3 && playerAnswer == "TIME")
        {
            if (resultText != null)
                resultText.text = "Correct. The barrier opens.";

            if (barrierToUnlock != null)
                barrierToUnlock.SetActive(false);

            Invoke(nameof(ClosePuzzle), 1.5f);
            return;
        }

        if (resultText != null)
            scaryEffects.PlayScaryEffect();
            resultText.text = "Wrong... the barrier tightens.";
    }

    public void ClosePuzzle()
    {
        scaryEffects.PlayScaryEffect();
        if (puzzleBox != null)
            puzzleBox.SetActive(false);

        if (choiceButtonGroup != null)
            choiceButtonGroup.SetActive(true);

        if (wordPuzzleGroup != null)
            wordPuzzleGroup.SetActive(false);
    }
}