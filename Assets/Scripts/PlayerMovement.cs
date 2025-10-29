using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGrounded)
        {
            Debug.Log("����b�a��");
        }
        else
        {
            Debug.Log("����b�Ť�");
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("jump triggered");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        // ���k����
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ½�ਤ��
        if (moveInput > 0) sr.flipX = false;
        else if (moveInput < 0) sr.flipX = true;

        // �ˬd�O�_�b�a��
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // ���D�]�ť���^
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            print("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
