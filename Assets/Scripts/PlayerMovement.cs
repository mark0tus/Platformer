using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    Rigidbody2D rb;
    public Animator animator;

    public float speed;
    public float jumpForce;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float rememberGroundedFor;
    float lastTimeGrounded;

    public int defaultAdditionalJumps = 1;
    int additionalJumps;

    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    bool wallJumping;

    private bool m_FacingRight = true;
    private bool isSliding;
    private bool isFalling;

    public Transform spawnpoint;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        additionalJumps = defaultAdditionalJumps;
    }

    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();

        float input = Input.GetAxisRaw("Horizontal");
        

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkGroundRadius, groundLayer);
        if (isTouchingFront == true && isGrounded == false && input != 0)
        {
            wallSliding = true;
        }else
        {
            wallSliding = false;
        }
        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        if (rb.velocity.y == 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }
        if (rb.velocity.y > 0)
        {
            animator.SetBool("IsJumping", true);
        }
        if (rb.velocity.y < 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
    }


    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float moveBy = x * speed;

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveBy));

        if (moveBy > 0 && !m_FacingRight && !wallSliding)
        {
            Flip();
        }
        else if (moveBy < 0 && m_FacingRight && !wallSliding)
        {
            Flip();
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            additionalJumps--;
            animator.SetBool("IsJumping", true);
        }
    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            isGrounded = true;
            additionalJumps = defaultAdditionalJumps;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }
    private void Flip()
    {       
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void Respawn()
    {
        player.transform.position = spawnpoint.position; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            Respawn();
        }

        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Extrapolate;
            transform.parent = other.transform.parent.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Interpolate;
            transform.parent = null;
        }
    }
    /*public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }*/
}