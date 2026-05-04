using UnityEngine;

public class ClueObjectInteraction : MonoBehaviour
{
    public InspectionManager inspectionManager;
    public Sprite clueSprite;

    private void OnMouseDown()
    {
        if (inspectionManager == null || clueSprite == null)
        {
            Debug.LogError(gameObject.name + " missing setup.");
            return;
        }

        inspectionManager.ShowInspection(clueSprite);
    }
}
