using UnityEngine;
using System.Collections;

public class PuzzleLight : MonoBehaviour
{
    public int lightIndex;
    public SpriteRenderer spriteRenderer;
    public GameObject plusGlow;

    public Color normalColor = new Color(0.7f, 0.2f, 0.6f, 1f);
    public Color flashColor = Color.yellow;
    public Color successColor = Color.green;
    public Color failColor = Color.red;
    public Color hitColor = Color.blue;

    private Vector3 originalScale;

    private void Awake()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        originalScale = transform.localScale;
        ResetVisible();
    }

    public void ResetVisible()
    {
        gameObject.SetActive(true);
        spriteRenderer.color = normalColor;
        transform.localScale = originalScale;

        if (plusGlow != null)
            plusGlow.SetActive(true);
    }

    public void FlashOn()
    {
        gameObject.SetActive(true);
        spriteRenderer.color = flashColor;

        if (plusGlow != null)
            plusGlow.SetActive(true);
    }

    public void SetSuccess()
    {
        gameObject.SetActive(true);
        spriteRenderer.color = successColor;

        if (plusGlow != null)
            plusGlow.SetActive(true);
    }

    public void SetFail()
    {
        gameObject.SetActive(true);
        spriteRenderer.color = failColor;

        if (plusGlow != null)
            plusGlow.SetActive(true);
    }

    public IEnumerator PopDisappearEffect()
    {
        spriteRenderer.color = hitColor;

        if (plusGlow != null)
            plusGlow.SetActive(false);

        transform.localScale = originalScale * 1.4f;
        yield return new WaitForSeconds(0.12f);

        transform.localScale = originalScale * 0.5f;
        yield return new WaitForSeconds(0.08f);

        gameObject.SetActive(false);
    }
}