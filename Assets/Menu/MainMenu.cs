using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject savePanel;

    public void StartNewGame()
    {
        savePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        savePanel.SetActive(true);
    }

    public void SelectSlot1()
    {
        Debug.Log("Slot 1 selected");
        SceneManager.LoadScene("Room1");
    }

    public void SelectSlot2()
    {
        Debug.Log("Slot 2 Selected");
        SceneManager.LoadScene("Room1");
    }

    public void CloseSavePanel()
    {
        savePanel.SetActive(false);
    }

    public void OpenSettings()
    {
        Debug.Log("Settings clicked");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit clicked");
    }
}
