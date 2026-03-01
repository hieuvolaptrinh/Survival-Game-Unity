using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision){
       if(collision.gameObject.CompareTag("Usb")){
          Debug.Log("Player collided with USB");
          Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Energy")){
          
          gameManager.AddEnergy();
       Destroy(collision.gameObject);
        }
        
}}

