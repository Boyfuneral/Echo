using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
public LayerMask interactLayer;
    private InteractableHighlight currentHighlight;

    void Start() {
        //Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.Confined; 
    }

    void Update()
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D hit = Physics2D.OverlapPoint(mousePosition, interactLayer);

        if (DialogueManager.Instance.IsDialogueActive || PuzzleManager.Instance.isPuzzleActive)
        {
            
            if (currentHighlight != null)
            {
                currentHighlight.highlight.SetActive(false);
                currentHighlight = null;
            }
            return; 
        }


        if (hit != null)
        {
            InteractableHighlight highlight = hit.GetComponent<InteractableHighlight>();
            
            if (highlight != null && highlight != currentHighlight)
            {
                if (currentHighlight != null) currentHighlight.highlight.SetActive(false);
                currentHighlight = highlight;
                currentHighlight.highlight.SetActive(true);
            }
        }
        else
        {
            if (currentHighlight != null)
            {
                currentHighlight.highlight.SetActive(false);
                currentHighlight = null;
            }
        }


        if (Input.GetMouseButtonDown(0) && hit != null) 
        {
            Interactable interactable = hit.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
