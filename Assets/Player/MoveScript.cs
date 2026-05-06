using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float speed = 3f;

    //public Sprite upSprite;
    //public Sprite downSprite;
    //public Sprite leftSprite;
    //public Sprite rightSprite;


    private SpriteRenderer sr;
    public Rigidbody2D rb;

    public bool canMove = true;
    public bool isTrapped;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // /*

    private void Start() {
        //specific to scene 1
        isTrapped = true;
        rb.gravityScale = 0; 
    }

    void FixedUpdate()
    {
        if (!canMove || isTrapped) 
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        UpdateSpriteDirection(horizontalInput);
        
        
    }

    void UpdateSpriteDirection(float moveInput)
    {

        if (moveInput > 0)
        {
            sr.flipX = false; 
        }
        else if (moveInput < 0)
        {
            sr.flipX = true;  
        }
    }

   
        
    // */

    //old movement system - changing for sidescroller version, but keeping this code in case we want to revert back to top-down
    /*
    private void Start() {
        //specific to scene 1
        isTrapped = true;
    }
    void FixedUpdate()
    {
        if (!canMove | isTrapped) 
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 movement =
            new Vector2(Input.GetAxisRaw("Horizontal"),
                        Input.GetAxisRaw("Vertical")).normalized;

        rb.linearVelocity = movement * speed;

        UpdateSprite(movement);
    }

    void UpdateSprite(Vector2 movement)
    {
        if (movement == Vector2.zero) return;

        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            sr.sprite = movement.x > 0 ? rightSprite : leftSprite;
        else
            sr.sprite = movement.y > 0 ? upSprite : downSprite;
    }

    public void FaceDirection(Vector2 direction)
    {
        if (direction == Vector2.up)
            sr.sprite = upSprite;
        else if (direction == Vector2.down)
            sr.sprite = downSprite;
        else if (direction == Vector2.left)
            sr.sprite = leftSprite;
        else if (direction == Vector2.right)
            sr.sprite = rightSprite;
    }

    public void MoveToPosition(Vector2 position, Vector2 faceDirection)
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = position;

        FaceDirection(faceDirection);

        canMove = false;
    }
    */

}
