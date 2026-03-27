using System.Collections;
using UnityEngine;

public class Room2Manager : MonoBehaviour
{
    [System.Serializable]
    public class Pair
    {
        public string name;
        public Transform left;
        public Transform right;

        private Vector3 leftPos, rightPos;
        private Vector3 leftRot, rightRot;

        public void Capture()
        {
            leftPos = left.localPosition;
            rightPos = right.localPosition;
            leftRot = left.localEulerAngles;
            rightRot = right.localEulerAngles;
        }

        public void ResetCorrect()
        {
            left.localPosition = leftPos;
            right.localPosition = rightPos;
            left.localEulerAngles = leftRot;
            right.localEulerAngles = rightRot;
        }

        public void ApplyFault()
        {
            // subtle wrong: tiny rotation difference on right
            right.localEulerAngles = rightRot + new Vector3(0, 0, 6f);
        }
    }

    [Header("Pairs 0..5 match switches 1..6")]
    public Pair[] pairs = new Pair[6];

    [Header("Overlay (flicker + blackout)")]
    public SpriteRenderer overlay;

    [Header("Rules")]
    public int maxMistakes = 3;

    private int faultyIndex;
    private int mistakes;
    private bool solved;

    void Start()
    {
        // Capture correct symmetry state
        for (int i = 0; i < pairs.Length; i++)
            pairs[i].Capture();

        // Pick faulty pair and apply mismatch
        faultyIndex = Random.Range(0, pairs.Length);
        pairs[faultyIndex].ApplyFault();

        mistakes = 0;
        solved = false;

        Debug.Log("Faulty pair = " + pairs[faultyIndex].name);
    }

    public void PressSwitch(int index)
    {
        if (solved) return;

        if (index == faultyIndex)
        {
            solved = true;
            pairs[faultyIndex].ResetCorrect();
            Debug.Log("Pattern recognition acceptable.");
        }
        else
        {
            mistakes++;
            Debug.Log("Wrong switch. Mistakes: " + mistakes);
            StartCoroutine(Flicker());

            if (mistakes >= maxMistakes)
                StartCoroutine(Blackout());
        }
    }

    private IEnumerator Flicker()
    {
        if (overlay == null) yield break;

        float t = 0.6f;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            overlay.enabled = !overlay.enabled;
            yield return null;
        }
        overlay.enabled = false;
    }

    private IEnumerator Blackout()
    {
        if (overlay == null) yield break;

        overlay.enabled = true;
        yield return new WaitForSeconds(3f);
        overlay.enabled = false;
    }
}