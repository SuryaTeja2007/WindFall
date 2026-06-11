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

    private float timeElapsed = 0f;
    private bool timerRunning = false;
    private bool gamePaused = false;

    void Start()
    {
        Time.timeScale = 0f;

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
        if (startScreen != null)
            startScreen.SetActive(false);

        if (pauseButton != null)
            pauseButton.SetActive(true);

        if (timerText != null)
            timerText.gameObject.SetActive(true);

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