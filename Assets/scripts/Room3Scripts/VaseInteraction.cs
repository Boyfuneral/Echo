using UnityEngine;

public class VaseInteraction : MonoBehaviour
{
    public InspectionManager inspectionManager;
    public Sprite vaseWithKeyCloseup;

    private void OnMouseDown()
    {
        if (inspectionManager == null || vaseWithKeyCloseup == null)
        {
            Debug.LogError(gameObject.name + "missing vase inspection setup.");
            return;
        }

        inspectionManager.ShowInspection(vaseWithKeyCloseup);
    }
}
