using UnityEngine;
using UnityEngine.UI;
using Unity.Cinemachine;
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
    [SerializeField] private AudioManager audioManager;
[SerializeField] private GameObject winMenu;

[SerializeField] private CinemachineCamera cinemachineCamera;

// red 
[SerializeField] private GameObject red;
    void Start()
    {

        boss.SetActive(false);
        gameUI.SetActive(true);
        currentEnergy = 0;
        UpdateEnergyBar();
        MainMenu();
        audioManager.StopBackgroundMusic();
        cinemachineCamera.Lens.OrthographicSize = 7f; // Đặt lại kích thước camera về mặc định
        red.SetActive(false);
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

        audioManager.PlayBossMusic();
        cinemachineCamera.Lens.OrthographicSize = 10;
        red.SetActive(true);
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
winMenu.SetActive(false);

Time.timeScale = 0f; // Tạm dừng trò chơi
    }
    public void PauseGame(){
      pauseMenu.SetActive(true);
      mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f; // Tạm dừng trò chơi
    }
    public void GameOverMenu(){
      gameOverMenu.SetActive(true);
        mainMenu.SetActive(false);
            pauseMenu.SetActive(false);
            winMenu.SetActive(false);
    }
    public void StartGame(){
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f; // Tiếp tục trò chơi
        audioManager.PlayDefaultMusic();
        
    }
     public void ResumeGame(){
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f; // Tiếp tục trò chơi
    }
    public void WinGame(){
        winMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 0f; // Tạm dừng trò chơi
    }
}
