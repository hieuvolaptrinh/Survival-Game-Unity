using UnityEngine;

public class EnergyEnemy : Enemy
{

[SerializeField] private GameObject energyObject;

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

// chết thì tạo ra năng lượng
    public override void Die(){
        if(energyObject != null){
            GameObject energy =Instantiate(energyObject, transform.position, Quaternion.identity);
            Destroy(energy, 5f); // hủy năng lượng sau 5 giây
        }
        base.Die(); // Gọi phương thức Die() của lớp cha (Enemy)
    }
}
