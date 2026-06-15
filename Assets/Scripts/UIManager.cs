using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject winScreen;
    public GameObject pauseScreen;
    public GameObject pauseButton;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI heightText;

    public Transform player;

    private float timeElapsed = 0f;
    private bool timerRunning = false;
    private bool gamePaused = false;

    private float startHeight;

    void Start()
    {
        Time.timeScale = 0f;

        if (player != null)
            startHeight = player.position.y;

        startScreen.SetActive(true);
        winScreen.SetActive(false);
        pauseScreen.SetActive(false);
        pauseButton.SetActive(false);

        timerText.gameObject.SetActive(false);
        heightText.gameObject.SetActive(false);

        timerText.text = "00:00";
        heightText.text = "Height: 0m";
    }

    void Update()
    {
        // Timer
        if (timerRunning)
        {
            timeElapsed += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeElapsed / 60);
            int seconds = Mathf.FloorToInt(timeElapsed % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        // Height Meter
        if (player != null)
        {
            float height = Mathf.Max(0, player.position.y - startHeight);
            heightText.text = "Height: " + Mathf.RoundToInt(height) + "m";
        }

        // ESC Pause / Resume
        if (Input.GetKeyDown(KeyCode.Escape) && !startScreen.activeSelf)
        {
            if (gamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        winScreen.SetActive(false);
        pauseScreen.SetActive(false);

        pauseButton.SetActive(true);

        timerText.gameObject.SetActive(true);
        heightText.gameObject.SetActive(true);

        timeElapsed = 0f;
        timerRunning = true;
        gamePaused = false;

        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);

        timerRunning = false;
        gamePaused = true;

        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);

        timerRunning = true;
        gamePaused = false;

        Time.timeScale = 1f;
    }

    public void ShowWinScreen()
    {
        timerRunning = false;

        startScreen.SetActive(false);
        pauseScreen.SetActive(false);
        pauseButton.SetActive(false);

        winScreen.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}