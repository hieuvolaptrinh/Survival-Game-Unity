using UnityEngine;

public class HealEnemy : Enemy
{
 
// lượng máu hồi lại cho player
[SerializeField] private float healValue = 20f;

// Logic gây damage đã được thừa kế từ class Enemy

public override void Die(){
    base.Die();
       HealPlayer();
    }

    public  void HealPlayer(){
        player.Heal(healValue);
    }
}
