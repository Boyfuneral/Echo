using UnityEngine;
using System.Collections.Generic;

public class Room3SequenceInput : MonoBehaviour
{
    public List<int> correctSequence = new List<int> { 5, 3, 2, 6, 6, 6 };
    private List<int> playerInput = new List<int>();

    public GameObject lockedDoor;
    public GameObject openDoor;
    public ScaryEffectAlternative scaryEffects;
    public GameObject exit;

     void Start()
    {
        lockedDoor.SetActive(true);
        openDoor.SetActive(false);
    }

    public void PressNumber(int number)
    {
        playerInput.Add(number);
        Debug.Log("Pressed: " + number);

        int index = playerInput.Count - 1;

        if (playerInput[index] != correctSequence[index])
        {
            Debug.Log("Wrong code. Reset.");
            playerInput.Clear();
            scaryEffects.PlayScaryEffect();
            return;
            
        }

        if (playerInput.Count == correctSequence.Count)
        {
            Debug.Log("Correct code. Door unlocked.");

            lockedDoor.SetActive(false);
            openDoor.SetActive(true);
            exit.SetActive(true);

            playerInput.Clear();
        }
    }
}
