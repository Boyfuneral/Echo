using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public GameObject roundTextBox;
    public TextMeshProUGUI roundText;

    void Start()
    {
        ResetLights();

        if (roundTextBox != null)
            roundTextBox.SetActive(false);
    }

    public void StartPuzzle()
    {
        currentRound = 1;
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

        yield return StartCoroutine(ShowRoundMessage("The path opens.\nRun."));

        if (barrierToOpen != null)
            barrierToOpen.SetActive(false);
    }

    IEnumerator FailPuzzle()
    {
        playerCanInput = false;
        puzzleActive = false;

        foreach (PuzzleLight light in lights)
            light.SetFail();

        yield return StartCoroutine(ShowRoundMessage("Wrong.\nThe forest takes you."));

        if (player != null && playerSpawnPoint != null)
            player.transform.position = playerSpawnPoint.position;

        ResetLights();
        currentRound = 1;

        yield return new WaitForSeconds(0.7f);

        StartCoroutine(StartRound());
    }

    IEnumerator ShowRoundMessage(string message)
    {
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
        return "ROUND " + currentRound;
    }

    string GetRoundCompleteMessage()
    {
        return "Good...";
    }

    public void ResetLights()
    {
        foreach (PuzzleLight light in lights)
        {
            if (light != null)
                light.ResetVisible();
        }
    }
}