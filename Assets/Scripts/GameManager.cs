using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int currentEnergy;
    [SerializeField] private int energyThreshold = 3;
    [SerializeField] private GameObject boss;
    private bool bossSpawned = false;
    [SerializeField] private GameObject enemySpawner;

    //  làm việc với image
    [SerializeField] private Image energyBar; // Tham chiếu đến Image của thanh năng lượng\\
    [SerializeField] private GameObject gameUI; // Tham chiếu đến Image của thanh HP

    // Tương tác với các menu
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;

    void Start()
    {

        boss.SetActive(false);
        gameUI.SetActive(true);
        currentEnergy = 0;
        UpdateEnergyBar();
    }

    public void AddEnergy()
    {

        if (bossSpawned) return; // Nếu boss đã xuất hiện, không cần thêm năng lượng nữa
        currentEnergy++;
        UpdateEnergyBar();
        if (currentEnergy >= energyThreshold && !bossSpawned)
        {
            CallBoss();
        }



    }

    public void CallBoss()
    {
        bossSpawned = true;
        boss.SetActive(true);
        enemySpawner.SetActive(false);
        gameUI.SetActive(false);
    }

    private void UpdateEnergyBar()
    {
        if (energyBar != null)
        {
            energyBar.fillAmount = (float)currentEnergy / energyThreshold;
        }
    }

    public void MainMenu(){
mainMenu.SetActive(true);
pauseMenu.SetActive(false);
gameOverMenu.SetActive(false);
    }
    public void PauseGame(){
      pauseMenu.SetActive(true);
      mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }
    public void GameOverMenu(){
      gameOverMenu.SetActive(true);
        mainMenu.SetActive(false);
            pauseMenu.SetActive(false);
    }
}
