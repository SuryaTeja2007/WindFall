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

        if (startScreen != null)
            startScreen.SetActive(true);

        if (winScreen != null)
            winScreen.SetActive(false);

        if (pauseScreen != null)
            pauseScreen.SetActive(false);

        if (pauseButton != null)
            pauseButton.SetActive(false);

        if (timerText != null)
        {
            timerText.text = "00:00";
            timerText.gameObject.SetActive(false);
        }

        if (heightText != null)
        {
            heightText.text = "Height: 0m";
            heightText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Test Win Screen with P key
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowWinScreen();
        }

        // Timer
        if (timerRunning)
        {
            timeElapsed += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeElapsed / 60);
            int seconds = Mathf.FloorToInt(timeElapsed % 60);

            if (timerText != null)
            {
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }

        // Height Meter
        if (player != null && heightText != null)
        {
            float height = Mathf.Max(0, player.position.y - startHeight);
            heightText.text = "Height: " + Mathf.RoundToInt(height) + "m";
        }

        // ESC Pause / Resume
        if (Input.GetKeyDown(KeyCode.Escape) &&
            startScreen != null &&
            !startScreen.activeSelf)
        {
            if (gamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void StartGame()
    {
        if (startScreen != null)
            startScreen.SetActive(false);

        if (pauseButton != null)
            pauseButton.SetActive(true);

        if (timerText != null)
            timerText.gameObject.SetActive(true);

        if (heightText != null)
            heightText.gameObject.SetActive(true);

        timerRunning = true;
        gamePaused = false;

        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (pauseScreen != null)
            pauseScreen.SetActive(true);

        timerRunning = false;
        gamePaused = true;

        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        if (pauseScreen != null)
            pauseScreen.SetActive(false);

        timerRunning = true;
        gamePaused = false;

        Time.timeScale = 1f;
    }

    public void ShowWinScreen()
    {
        timerRunning = false;

        if (pauseButton != null)
            pauseButton.SetActive(false);

        if (winScreen != null)
            winScreen.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}