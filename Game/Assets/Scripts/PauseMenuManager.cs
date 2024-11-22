using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pausePanel; // Asignar el panel de pausa en el Inspector.
    private bool isPaused = false;

    void Update()
    {
        // Detecta si se presiona la tecla Escape o el botón de pausa (configurable).
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // Detiene el tiempo del juego.
    }

    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // Restaura el tiempo del juego.
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Asegura que el tiempo se normalice.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Asegura que el tiempo se normalice.
        SceneManager.LoadScene("Menuinicio"); // Cambia "MainMenu" por el nombre de tu escena principal.
    }
}
