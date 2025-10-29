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
            Debug.Log("角色在地面");
        }
        else
        {
            Debug.Log("角色在空中");
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("jump triggered");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        // 左右移動
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 翻轉角色
        if (moveInput > 0) sr.flipX = false;
        else if (moveInput < 0) sr.flipX = true;

        // 檢查是否在地面
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // 跳躍（空白鍵）
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            print("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
