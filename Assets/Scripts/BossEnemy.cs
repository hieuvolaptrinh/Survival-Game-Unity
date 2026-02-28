using UnityEngine;

public class BossEnemy : Enemy
{

[SerializeField] private GameObject bulletPrefabs;
[SerializeField] private Transform firePoint;
[SerializeField] private float speedBasicBullet = 20f;
protected override void Update(){
   base.Update();
   if(Input.GetKeyDown(KeyCode.Space)){
       BasicShoot();
    }
    
}
//    các kỹ năng của boss
// bắn đạn thường
private void BasicShoot(){
    // logic bắn đạn thường
    if(player != null){
        Vector3 directionToPlayer = (player.transform.position - firePoint.position);
        directionToPlayer.Normalize();
        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);   
        EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
        enemyBullet.SetMovementDirection(directionToPlayer);
    }
}
// bán đạn vòng tròn
private void CircleShoot(){
    // logic bắn đạn vòng tròn
}
// Hồi máu
private void Heal(){
    // logic hồi máu
}
// tạo ra mini enemy
private void SpawnMinions(){
    // logic tạo ra mini enemy
}

// dịch chuyển tới player 


}
