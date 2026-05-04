using UnityEngine;
using UnityEngine.UI;

public class InspectionManager : MonoBehaviour
{
    public GameObject inspectionPanel;
    public Image closeupImage;

    private void Start()
    {
        inspectionPanel.SetActive(false);
    }

    public void ShowInspection(Sprite clueSprite)
    {
        closeupImage.sprite = clueSprite;
        inspectionPanel.SetActive(true);
    }

    public void CloseInspection()
    {
        inspectionPanel.SetActive(false);
    }
}
