using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NivelBetaController : MonoBehaviour
{
    public GameObject panelEnDesarrollo; // Panel con el mensaje de advertencia
    public Button botonIniciarNivel; // Botón para iniciar el nivel

    private void Start()
    {
        // Asegurarse de que el panel esté desactivado al iniciar
        panelEnDesarrollo.SetActive(false);

        // Asignar el método al botón
        botonIniciarNivel.onClick.AddListener(MostrarAdvertencia);
    }

    // Método para mostrar el panel de advertencia
    void MostrarAdvertencia()
    {
        panelEnDesarrollo.SetActive(true);
    }

    // Método para ocultar el panel y proceder con el nivel
    public void ContinuarConNivel()
    {
        panelEnDesarrollo.SetActive(false);
        // Aquí puedes agregar el código para cambiar de escena si lo deseas
        // Por ejemplo:
        // SceneManager.LoadScene("NombreDelNivel");
    }
}


