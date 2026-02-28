using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // để lật nhân vật nếu di chuyển qua trái
    private Animator animator;// để nhận viết là đang đứng yên hay di chuyển vì có đặt biến isRun

    [SerializeField] private float maxHp = 100f;
    private float currentHp;
    [SerializeField] private Image hpBar; // Tham chiếu đến Image của thanh HP



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        currentHp = maxHp;
        UpdateHpBar();
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

    public void TakeDamage(float damage){
        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if(currentHp <= 0){
            Die();
        }
    }
    public void Die(){
       Destroy(gameObject);
    }
    private void UpdateHpBar(){
        if(hpBar != null){
            hpBar.fillAmount = currentHp / maxHp; // là phần ui canva đã tạo có property fillAmount để hiển thị phần trăm hp còn lại
        }
    }

    public void Heal(float healAmount){
       if(currentHp < maxHp){
           currentHp += healAmount;
           currentHp = Mathf.Min(currentHp, maxHp);
           UpdateHpBar();
       }
    }
}