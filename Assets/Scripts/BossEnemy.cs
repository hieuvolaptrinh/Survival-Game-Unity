using UnityEngine;

public class BossEnemy : Enemy
{

[SerializeField] private GameObject bulletPrefabs;
[SerializeField] private Transform firePoint;
[SerializeField] private float speedBasicBullet = 5f;
[SerializeField] private float speedCircleShoot = 2f;
[SerializeField] private float hpValue = 20f;
[SerializeField] private GameObject miniEnemy;
[SerializeField] private float skillCooldown = 1f;
private float nextSkillTime = 0f;
[SerializeField] private GameObject usbPrefabs;

protected override void Update(){
   base.Update();
  if(Time.time >= nextSkillTime){
    UseSkill();
  }
    
}
public override void Die(){
    base.Die();
    Instantiate(usbPrefabs, transform.position, Quaternion.identity);
}
//    các kỹ năng của boss
// bắn đạn thường
private void BasicShoot(){
    // logic bắn đạn thường
    if(player != null){
        Vector3 directionToPlayer = player.transform.position - firePoint.position;
        directionToPlayer.Normalize();
        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);   
        EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
       
            enemyBullet.SetMovementDirection(directionToPlayer * speedBasicBullet);
        
    }
}
// bán đạn vòng tròn
private void CircleShoot(){
    const int bulletCount=12;
    float angleStep = 360f / bulletCount;
    for(int i=0; i<bulletCount; i++){
        float angle = i * angleStep;
        Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
        EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
        enemyBullet.SetMovementDirection(direction * speedCircleShoot);
    }
}
// Hồi máu
private void Heal(float healAmount){
    // logic hồi máu
    currentHp += healAmount;
    if(currentHp > maxHp){
        currentHp = maxHp;
    }
    UpdateHpBar();
}
// tạo ra mini enemy
private void SpawnMinions(){
    // logic tạo ra mini enemy
    Instantiate(miniEnemy, transform.position , Quaternion.identity);
}

// dịch chuyển tới player 
private void MoveTowardsPlayer(){
    if(player != null){
        
        transform.position =player.transform.position + new Vector3(0, 1, 0); // Dịch chuyển lên trên một chút so với vị trí của player
    }
}

private void RandomSkill(){
   int randomSkill = Random.Range(0,5);
    switch(randomSkill){
     case 0:
          BasicShoot();
          break;
     case 1:
          CircleShoot();
          break;
     case 2:
          Heal(hpValue);
          break;
     case 3:
          SpawnMinions();
          break;
     case 4:
          MoveTowardsPlayer();
          break;
    }
}
private void UseSkill(){
   nextSkillTime = Time.time + skillCooldown;
   RandomSkill();
    }

}
