using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isJumping;
    private bool isFacingRight;
    private float jumpTimer = 0.1f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isFacingRight = true;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * horizontalMove, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (horizontalMove > 0 && !isFacingRight)
        {
            spriteRenderer.flipX = false;
            isFacingRight = true;
        }
        else if (horizontalMove < 0 && isFacingRight)
        {
            spriteRenderer.flipX = true;
            isFacingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Debug.Log("Jump");
            Jump();
        }

        if (isJumping)
        {
            if (jumpTimer <= 0f && IsGrounded())
            {
                isJumping = false;
                animator.SetBool("Jump", false);
            }
            jumpTimer -= Time.deltaTime;
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        animator.SetBool("Jump", true);
        isJumping = true;
        jumpTimer = 0.1f;
        // Big change here
        // I will make this a merge conflict
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.52f, groundLayer.value);
    }
}
