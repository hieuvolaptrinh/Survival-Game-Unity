using UnityEngine;

public class ExplosionEnemy : Enemy
{
   [SerializeField] private GameObject explosionPrefab;

   private void CreateExplosion(){
       if(explosionPrefab != null){
           Instantiate(explosionPrefab, transform.position, Quaternion.identity);
       }
   }
   public override void Die(){
       base.Die();
       CreateExplosion();
   }

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
}
