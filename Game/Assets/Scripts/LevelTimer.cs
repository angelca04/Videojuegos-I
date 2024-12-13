using UnityEngine;
using TMPro; // Necesario para TextMeshPro.

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Campo para el texto del temporizador.
    public GameObject levelCompletePanel; // Panel de "Bien Hecho".
    public AudioClip completionSound; // Sonido al completar el nivel.
    public float levelTime = 120f; // Tiempo total en segundos.

    private float currentTime;
    private bool isRunning = true;
    private AudioSource audioSource;

    void Start()
    {
        currentTime = levelTime;
        UpdateTimerUI(); // Actualiza el texto del temporizador al inicio.
        levelCompletePanel.SetActive(false); // Asegura que el panel esté oculto al iniciar.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Añade un AudioSource si no existe.
        }
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
            UpdateTimerUI(); // Actualiza el texto del temporizador cada frame.
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

        // Reproducir el sonido de finalización si está configurado.
        if (completionSound != null)
        {
            audioSource.PlayOneShot(completionSound);
        }
    }

    // Métodos para los botones:
    public void RetryLevel()
    {
        Time.timeScale = 1f; // Restaura el tiempo.
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void SelectLevel()
    {
        Time.timeScale = 1f; // Restaura el tiempo.
        UnityEngine.SceneManagement.SceneManager.LoadScene("selectnivel"); // Cambia "LevelSelection" por el nombre de tu escena de selección de nivel.
    }
}
