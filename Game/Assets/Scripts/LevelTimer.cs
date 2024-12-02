using UnityEngine;
using TMPro; // Si usas TextMeshPro, incluye este namespace.

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Arrastra el objeto TimerText aquí (para TextMeshPro).
    // Si usas un UI Text normal, usa `public Text timerText;` y elimina la línea `using TMPro;`.

    public float levelTime = 120f; // Tiempo total en segundos para el nivel.
    private float currentTime;
    private bool isRunning = true;

    void Start()
    {
        currentTime = levelTime; // Inicializa el tiempo al comienzo del nivel.
        UpdateTimerUI(); // Muestra el tiempo inicial.
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime; // Reduce el tiempo basado en el tiempo real.
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isRunning = false;
                OnTimeUp(); // Llama a la función cuando se acabe el tiempo.
            }
            UpdateTimerUI(); // Actualiza el texto del temporizador.
        }
    }

    void UpdateTimerUI()
    {
        // Convierte los segundos en formato MM:SS.
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

   void OnTimeUp()
{
    // Ejemplo: Pausar el juego y mostrar un mensaje.
    Time.timeScale = 0f; // Pausa el juego.
    Debug.Log("¡El tiempo se ha agotado! Fin del nivel.");
    // Puedes añadir más lógica, como cargar un menú de "Game Over".
}
}
