using UnityEngine;

public class SimpleLightPulse : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float pulseAmount = 0.15f;

    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        float pulse = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = startScale * pulse;
    }
}