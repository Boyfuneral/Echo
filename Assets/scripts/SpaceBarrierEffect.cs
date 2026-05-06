using UnityEngine;

public class SpaceBarrierEffect : MonoBehaviour
{
    public float waveSpeed = 2f;
    public float swayAmount = 0.04f;
    public float stretchAmount = 0.08f;
    public float alphaMin = 0.25f;
    public float alphaMax = 0.65f;

    private Vector3 startLocalPos;
    private Vector3 startScale;
    private SpriteRenderer sr;
    private Color startColor;

    void Start()
    {
        startLocalPos = transform.localPosition;
        startScale = transform.localScale;
        sr = GetComponent<SpriteRenderer>();
        startColor = sr.color;
    }

    void Update()
    {
        float wave = Mathf.Sin(Time.time * waveSpeed);
        float wave2 = Mathf.Sin(Time.time * waveSpeed * 1.7f);

        // tiny side-to-side energy sway
        transform.localPosition = startLocalPos + new Vector3(wave * swayAmount, 0, 0);

        // vertical breathing/stretching effect
        transform.localScale = new Vector3(
            startScale.x + wave2 * stretchAmount,
            startScale.y + wave * stretchAmount,
            startScale.z
        );

        // soft fade pulse
        Color c = startColor;
        c.a = Mathf.Lerp(alphaMin, alphaMax, (wave + 1f) / 2f);
        sr.color = c;
    }
}