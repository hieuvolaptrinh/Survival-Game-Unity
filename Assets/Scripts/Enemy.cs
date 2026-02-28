using UnityEngine;
using UnityEngine.UI;
public abstract class Enemy : MonoBehaviour{
    [SerializeField] protected float enemyMoveSpeed = 1f;
    protected Player player;
    protected Rigidbody2D rb;
    [SerializeField] protected float maxHp =50f;
    protected float currentHp;
    [SerializeField] protected Image hpBar; // Tham chiếu đến Image của thanh HP
[SerializeField] protected float enterDamage = 10f; 
[SerializeField] protected float stayDamage = 1f; // Thời gian sau khi va chạm với player sẽ bị hủy

    protected virtual void Start(){
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
        UpdateHpBar();
    }

    protected virtual void Update(){
        MoveToPlayer();
    }
protected void MoveToPlayer(){
    if(player !=null && rb != null){
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = direction * enemyMoveSpeed;
        FlipEnemy();
    }
}
protected void FlipEnemy(){
    if(player != null){
       transform.localScale = new Vector3(transform.position.x < player.transform.position.x ? 1 : -1, 1, 1);
    }
    
}
public virtual void TakeDamage(float damage){
 currentHp -= damage;
 currentHp=Mathf.Max(currentHp, 0);
 if(currentHp <= 0){
     Die();
 }
 UpdateHpBar();
}
public virtual void Die(){
    Destroy(gameObject);
}

protected virtual void OnCollisionEnter2D(Collision2D collision){
    if(collision.gameObject.CompareTag("Player")){
        Player playerComponent = collision.gameObject.GetComponent<Player>();
        if(playerComponent != null){
            playerComponent.TakeDamage(enterDamage);
        }
    }
}

protected virtual void OnCollisionStay2D(Collision2D collision){
    if(collision.gameObject.CompareTag("Player")){
        Player playerComponent = collision.gameObject.GetComponent<Player>();
        if(playerComponent != null){
            playerComponent.TakeDamage(stayDamage * Time.deltaTime);
        }
    }
}

protected void UpdateHpBar(){
    if(hpBar != null){
        hpBar.fillAmount = currentHp / maxHp; // là phần ui canva đã tạo có property fillAmount để hiển thị phần trăm hp còn lại
    }
}
}