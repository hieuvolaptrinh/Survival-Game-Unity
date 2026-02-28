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
   
   // Logic gây damage đã được thừa kế từ class Enemy
}
