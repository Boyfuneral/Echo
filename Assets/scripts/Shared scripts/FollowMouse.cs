using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clickSound;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        transform.position = Input.mousePosition;

        // Left click sound
        if (Input.GetMouseButtonDown(0))
        {
            PlaySound(clickSound);
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip == null || audioSource == null)
            return;

        audioSource.PlayOneShot(clip);
    }
}
