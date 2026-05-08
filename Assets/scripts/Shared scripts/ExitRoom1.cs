using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitRoom1 : MonoBehaviour
{
    public TransitionOutOfScene transition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transition.StartFade();
        }
    }
}
