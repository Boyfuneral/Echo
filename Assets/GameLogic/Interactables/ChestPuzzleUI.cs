using UnityEngine;
using TMPro;

public class ChestPuzzleUI : MonoBehaviour
{
    public int[] currentCode = new int[6];
    public int[] correctCode = { 3, 1, 4, 5, 1, 2 }; 
    public TextMeshProUGUI[] digitTexts; 

    [Header("Visuals & UI")]
    public GameObject numberControlsParent; 
    public GameObject closedChestImage;    
    public GameObject openChestImage;

    void Start()
    {
        
        closedChestImage.SetActive(true);
        openChestImage.SetActive(false);
        numberControlsParent.SetActive(true);
        
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PuzzleManager.Instance.EndPuzzle(gameObject);
        }
    }

    public void IncrementDigit(int index)
    {
        currentCode[index]++;
        if (currentCode[index] > 9) currentCode[index] = 0; 
        UpdateUI();
        CheckCode();
    }

  
    public void DecrementDigit(int index)
    {
        currentCode[index]--;
        if (currentCode[index] < 0) currentCode[index] = 9; 
        UpdateUI();
        CheckCode();
    }

    void UpdateUI()
    {
        for (int i = 0; i < digitTexts.Length; i++)
        {
            digitTexts[i].text = currentCode[i].ToString();
        }
    }

    void CheckCode()
    {

        for (int i = 0; i < correctCode.Length; i++)
        {
            if (currentCode[i] != correctCode[i])
            {
                return; 
            }
        }

        UnlockChest();
    }

    void UnlockChest()
    {
        Debug.Log("Chest Unlocked! Revealing strap code.");

        numberControlsParent.SetActive(false);

        closedChestImage.SetActive(false);
        openChestImage.SetActive(true); 

    }


}
