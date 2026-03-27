using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public RoomController room;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            room.EnterRoom();
        }
    }
}
