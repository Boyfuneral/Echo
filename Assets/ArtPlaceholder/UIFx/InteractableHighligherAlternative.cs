using UnityEngine;

public class InteractableHighligherAlternative : MonoBehaviour
{
    public LayerMask interactLayer;

    private InteractableHighlight currentHighlight;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D hit = Physics2D.OverlapPoint(mousePosition, interactLayer);
        //Collider2D hit = Physics2D.OverlapPoint(mousePosition);
        if (hit != null)
        {
            InteractableHighlight highlight = hit.GetComponent<InteractableHighlight>();
            Debug.Log("Hit: " + hit.name);

            if (highlight != null && highlight != currentHighlight)
            {
                ClearHighlight();

                currentHighlight = highlight;
                currentHighlight.highlight.SetActive(true);
            }

            return;
        }

        ClearHighlight();
    }

    void ClearHighlight()
    {
        if (currentHighlight != null)
        {
            currentHighlight.highlight.SetActive(false);
            currentHighlight = null;
        }
    }
}
