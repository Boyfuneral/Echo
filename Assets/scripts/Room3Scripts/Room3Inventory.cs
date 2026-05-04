using UnityEngine;

public class Room3Inventory : MonoBehaviour
{
    private bool hasLockerKey = false;

    public void CollectLockerKey()
    {
        hasLockerKey = true;
        Debug.Log("Locker key collected.");
    }

    public bool HasLockerKey()
    {
        return hasLockerKey;
    }
}
