using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 25f;
    [SerializeField] private float timeDestroy = 0.5f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private GameObject bloodEffectPrefabs;
    void Start()
    {
         Destroy(gameObject, timeDestroy);
    }

    void Update()
    {
        MoveBullet();
       
    }

    void MoveBullet(){
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    // va chạm với enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if(enemy != null){
                enemy.TakeDamage(damage);
                GameObject bloodEffect = Instantiate(bloodEffectPrefabs, transform.position, Quaternion.identity);
                Destroy(bloodEffect,1f);
            }
            Destroy(gameObject);
        }
    }
}
