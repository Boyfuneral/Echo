using UnityEngine;
using System.Collections.Generic;

public class Room3PuzzleManager : MonoBehaviour
{
    public int requiredNormalPairs = 4;

    private int pendingPairNumber = -1;
    private bool pendingSideIsLeft;

    private HashSet<int> confirmedPairs = new HashSet<int>();
    private bool panelUnlocked = false;

    [Header("Panels")]
    public GameObject lockedPanel;
    public GameObject activePanel;

    [Header("Final Answer")]
    public int correctFaultyPairNumber = 6;

    [Header("Doors")]
    public GameObject lockedDoor;
    public GameObject openDoor;
    public ScaryEffectAlternative scaryEffects;

    private bool puzzleSolved = false;

    private void Start()
    {
        lockedPanel.SetActive(true);
        activePanel.SetActive(false);
    }

    public bool IsPanelUnlocked()
    {
        return panelUnlocked;
    }

    public void CheckObservationPair(int pairNumber, bool isFaultyPair, bool isLeftSide)
    {
        if (panelUnlocked)
            return;

        if (isFaultyPair)
        {
            ResetObservationPhase("ERROR. Faulty pair selected too early.");
            scaryEffects.PlayScaryEffect();
            return;
        }

        if (confirmedPairs.Contains(pairNumber))
        {
            ResetObservationPhase("ERROR. Pair is already confirmed.");
            return;
        }

        
        if (pendingPairNumber == -1)
        {
            pendingPairNumber = pairNumber;
            pendingSideIsLeft = isLeftSide;

            Debug.Log("First side selected for pair: " + pairNumber);
            return;
        }

        
        if (pendingPairNumber == pairNumber && pendingSideIsLeft != isLeftSide)
        {
            confirmedPairs.Add(pairNumber);

            Debug.Log("Pair confirmed: " + pairNumber + " | " + confirmedPairs.Count + "/" + requiredNormalPairs);

            pendingPairNumber = -1;

            if (confirmedPairs.Count >= requiredNormalPairs)
            {
                UnlockPanel();
            }

            return;
        }

        
        if (pendingPairNumber == pairNumber && pendingSideIsLeft == isLeftSide)
        {
            ResetObservationPhase("ERROR. Same side clicked twice.");
            scaryEffects.PlayScaryEffect();
            return;
        }

        if (pendingPairNumber != pairNumber)
        {
            ResetObservationPhase("ERROR. Pair sequence interrupted.");
            scaryEffects.PlayScaryEffect();
            return;
        }

    }

    private void UnlockPanel()
    {
        panelUnlocked = true;

        lockedPanel.SetActive(false);
        activePanel.SetActive(true);

        Debug.Log("Panel unlocked. Select faulty pair.");
    }

    private void ResetObservationPhase(string reason)
    {
        pendingPairNumber = -1;
        confirmedPairs.Clear();

        lockedPanel.SetActive(true);
        activePanel.SetActive(false);

        Debug.Log(reason + " Observation reset.");
    }

    private void SelectFaultyPair(int selectedPairNumber)
    {
        if (!panelUnlocked || puzzleSolved)
            return;

        if (selectedPairNumber == correctFaultyPairNumber)
        {
            SolvePuzzle();
        }
        else
        {
            Debug.Log("ERROR. Wrong faulty pair selected: " + selectedPairNumber);
        }
    }

    private void SolvePuzzle()
    {
        puzzleSolved = true;

        lockedDoor.SetActive(false);
        openDoor.SetActive(true);

        Debug.Log("PATTERN ACCEPTED. Door unlocked.");
    }
}
