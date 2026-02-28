using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // để lật nhân vật nếu di chuyển qua trái
    private Animator animator;// để nhận viết là đang đứng yên hay di chuyển vì có đặt biến isRun

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 playerInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        rb.linearVelocity = playerInput.normalized * moveSpeed;

        if (playerInput.x < 0) // di chuyển qua trái
            spriteRenderer.flipX = true;
        else if (playerInput.x > 0)
            spriteRenderer.flipX = false;

        // Cập nhật trạng thái chạy cho animator
        if(playerInput != Vector2.zero)
            animator.SetBool("isRun", true);
        else
            animator.SetBool("isRun", false);
    }

    public void TakeDamage(){
        Die();
    }
    public void Die(){
       Destroy(gameObject);
    }
}