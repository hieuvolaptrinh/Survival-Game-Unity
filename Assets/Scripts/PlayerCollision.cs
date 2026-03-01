using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;

    private void OnCollisionEnter2D(Collision2D collision){
       if(collision.gameObject.CompareTag("Usb")){
          gameManager.WinGame();
          
          Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Energy")){
          
          gameManager.AddEnergy();
          audioManager.PlayEnergySound();
       Destroy(collision.gameObject);
        }
        
}}

