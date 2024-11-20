using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    // Método que se llama al hacer clic en el botón
    public void OnRestartButtonClicked()
    {
        // Cambia a la escena del juego
        SceneManager.LoadScene("MiniGame"); // Asegúrate de que el nombre coincida exactamente
    }
}
