using UnityEngine;

public class Room3PlayerMove : MonoBehaviour
{
    public float speed = 4f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private SpriteRenderer sr;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = moveInput.normalized;

        if (moveInput.x > 0)
        {
            sr.flipX = false;
        }
        else if (moveInput.x < 0)
        {
            sr.flipX = true;
        }
        anim.SetFloat("PlayerSpeed", Mathf.Abs(moveInput.x) + Mathf.Abs(moveInput.y));
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }
}
