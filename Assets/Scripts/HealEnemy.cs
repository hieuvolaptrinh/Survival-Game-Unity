using UnityEngine;

public class HealEnemy : Enemy
{
 
// lượng máu hồi lại cho player
[SerializeField] private float healValue = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(enterDamage);
        }
    } 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(stayDamage);
        }
    }

public override void Die(){
    base.Die();
       HealPlayer();
    }

    public  void HealPlayer(){
        player.Heal(healValue);
    }
}
