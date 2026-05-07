using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LightPuzzleManager : MonoBehaviour
{
    public PuzzleLight[] lights;

    private List<int> currentSequence = new List<int>();
    private List<int> playerSequence = new List<int>();

    public int currentRound = 1;
    public int maxRounds = 5;

    public bool puzzleActive = false;
    public bool playerCanInput = false;
    public bool puzzleSolved = false;

    public GameObject barrierToOpen;
    public Transform playerSpawnPoint;
    public GameObject player;

    public GameObject lightPuzzleBox;
    public GameObject roundTextBox;
    public TextMeshProUGUI roundText;

    public Image roundBoxImage;

    public Sprite scrollSprite;
    public Sprite blendedSprite;
    public Sprite clipboardSprite;

    void Start()
    {
        ResetLights();

        if (roundTextBox != null)
            roundTextBox.SetActive(false);
    }

    public void OpenPuzzle()
    {
        if (lightPuzzleBox != null)
            lightPuzzleBox.SetActive(true);

        StartPuzzle();
    }

    public void StartPuzzle()
    {
        currentRound = 1;
        puzzleSolved = false;
        StartCoroutine(StartRound());
    }

    IEnumerator StartRound()
    {
        puzzleActive = true;
        playerCanInput = false;

        ResetLights();
        playerSequence.Clear();
        currentSequence.Clear();

        yield return StartCoroutine(ShowRoundMessage(GetRoundStartMessage()));

        GenerateSequence();

        yield return StartCoroutine(ShowSequence());

        playerCanInput = true;
    }

    void GenerateSequence()
    {
        int sequenceLength = currentRound + 1;

        for (int i = 0; i < sequenceLength; i++)
        {
            int randomLight = Random.Range(0, lights.Length);
            currentSequence.Add(randomLight);
        }
    }

    IEnumerator ShowSequence()
    {
        ResetLights();

        yield return new WaitForSeconds(0.7f);

        int currentStep = playerSequence.Count;
        int targetIndex = currentSequence[currentStep];

        lights[targetIndex].FlashOn();

        playerCanInput = true;
    }

    public void PlayerPressedLight(int index)
    {
        if (!puzzleActive || !playerCanInput || puzzleSolved)
            return;

        int currentStep = playerSequence.Count;
        int expectedLight = currentSequence[currentStep];

        if (index != expectedLight)
        {
            StartCoroutine(FailPuzzle());
            return;
        }

        playerSequence.Add(index);
        StartCoroutine(CorrectHit(index));
    }

    IEnumerator CorrectHit(int index)
    {
        playerCanInput = false;

        yield return StartCoroutine(lights[index].PopDisappearEffect());

        if (playerSequence.Count >= currentSequence.Count)
        {
            StartCoroutine(CompleteRound());
        }
        else
        {
            yield return new WaitForSeconds(0.4f);
            StartCoroutine(ShowSequence());
        }
    }

    IEnumerator CompleteRound()
    {
        playerCanInput = false;
        UpdateRoundVisual();
        yield return StartCoroutine(ShowRoundMessage(GetRoundCompleteMessage()));

        ResetLights();

        if (currentRound >= maxRounds)
        {
            StartCoroutine(SolvePuzzle());
        }
        else
        {
            currentRound++;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(StartRound());
        }
    }

    IEnumerator SolvePuzzle()
    {
        puzzleSolved = true;
        puzzleActive = false;

        foreach (PuzzleLight light in lights)
            light.SetSuccess();

        yield return StartCoroutine(ShowRoundMessage( "Proceed to Next Trial."));

        if (barrierToOpen != null)
            barrierToOpen.SetActive(false);
    }

    IEnumerator FailPuzzle()
    {
        playerCanInput = false;
        puzzleActive = false;

        foreach (PuzzleLight light in lights)
            light.SetFail();

        yield return StartCoroutine(ShowRoundMessage(GetFailureMessage()));

        if (player != null && playerSpawnPoint != null)
            player.transform.position = playerSpawnPoint.position;

        ResetLights();
        currentRound = 1;

        yield return new WaitForSeconds(0.7f);

        StartCoroutine(StartRound());
    }

    IEnumerator ShowRoundMessage(string message)
    {
        if (lightPuzzleBox != null)
            lightPuzzleBox.SetActive(true);

        if (roundTextBox != null)
            roundTextBox.SetActive(true);

        if (roundText != null)
            roundText.text = message;

        yield return new WaitForSeconds(1.6f);

        if (roundTextBox != null)
            roundTextBox.SetActive(false);
    }

    string GetRoundStartMessage()
    {
            switch (currentRound)
        {
            case 1:
                return "Round 1";

            case 2:
                return "Round 2";

            case 3:
                return "MEMORY TRIAL III";

            case 4:
                return "SUBJECT ECHO\nMemory Fragment Recovery Test";

            case 5:
                return "Do you remember now, Echo?";
        }

        return "ERROR";
    }

    string GetRoundCompleteMessage()
    {
        switch (currentRound)
        {
            case 1:
                return "Good.";

            case 2:
                return "Good. Keep going.";

            case 3:
                return "Subject response acceptable.";

            case 4:
                return "Memory returning.";

            case 5:
                return "Subject remembers.";
        }

        return "Complete.";
    }

    string GetFailureMessage()
    {
        switch (currentRound)
        {
            case 1:
                return "Wrong";

            case 2:
                return "Wrong. Try again.";

            case 3:
                return "Subject instability increasing.";

            case 4:
                return "Memory rejection detected.\nRestarting trial.";

            case 5:
                return "This is not your first attempt.";
        }

        return "Failure.";
    }

    public void ResetLights()
    {
        foreach (PuzzleLight light in lights)
        {
            if (light != null)
                light.ResetVisible();
        }
    }

    void UpdateRoundVisual()
    {
        if (currentRound <= 2)
        {
            roundBoxImage.sprite = scrollSprite;
        }
        else if (currentRound <= 3)
        {
            roundBoxImage.sprite = blendedSprite;
        }
        else
        {
            roundBoxImage.sprite = clipboardSprite;
        }
    }
}