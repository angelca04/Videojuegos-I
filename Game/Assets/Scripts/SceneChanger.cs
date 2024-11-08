using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneName; // Nombre de la escena a la que se va a cambiar

    // Método para cambiar de escena, lo puedes asignar en el botón desde el Inspector
    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("El nombre de la escena no está asignado.");
        }
    }
}

