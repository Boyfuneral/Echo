using UnityEngine;

public class LockerInteraction : MonoBehaviour
{
    public Room3Inventory inventory;
    public InspectionManager inspectionManager;

    public GameObject closedLocker;
    public GameObject openLocker;

    public Sprite sequenceNote;

    private bool isOpen = false;

    private void Start()
    {
        closedLocker.SetActive(true);
        openLocker.SetActive(false);
    }

    private void OnMouseDown()
    {
       if (isOpen)
        {
            inspectionManager.ShowInspection(sequenceNote);
            return;
        }

       if (inventory != null && inventory.HasLockerKey())
        {
            Debug.Log("Locker opened!");

            isOpen = true;
            closedLocker.SetActive(false);
            openLocker.SetActive(true);

            return;
        }

        Debug.Log("Locker is locked.");
    }

}
