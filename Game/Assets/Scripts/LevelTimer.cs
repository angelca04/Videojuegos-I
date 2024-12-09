using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Texto para mostrar el tiempo (TextMeshPro).
    public GameObject levelCompletePanel; // Panel de "Bien Hecho".

    public float levelTime = 120f; // Tiempo total en segundos.
    private float currentTime;
    private bool isRunning = true;

    void Start()
    {
        currentTime = levelTime;
        UpdateTimerUI();
        levelCompletePanel.SetActive(false); // Asegura que el panel esté oculto al iniciar.
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isRunning = false;
                ShowLevelCompletePanel(); // Muestra el panel cuando se acaba el tiempo.
            }
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ShowLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true); // Muestra el panel.
        Time.timeScale = 0f; // Pausa el juego.
    }

    // Métodos para los botones:
    public void RetryLevel()
    {
        Time.timeScale = 1f; // Restaura el tiempo.
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Restaura el tiempo.
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // Cambia "MainMenu" por el nombre de tu escena principal.
    }

    public void NextLevel()
    {
        Time.timeScale = 1f; // Restaura el tiempo.
        Debug.Log("¡Cargar siguiente nivel!"); // Aquí implementas la lógica para cargar el siguiente nivel.
        // Por ejemplo: SceneManager.LoadScene("NextLevel");
    }
}
