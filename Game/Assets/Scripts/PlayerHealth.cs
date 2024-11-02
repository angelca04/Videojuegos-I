using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Vida máxima del jugador
    public float currentHealth; // Vida actual del jugador
    public TextMeshProUGUI healthText; // Referencia al TextMesh Pro para mostrar la vida

    [Header("Configuración de Daño")]
    public float damageAmount = 0.5f; // Daño normal al chocar
    public float damageMultiplierAbove40 = 2f; // Multiplicador de daño cuando la vida está por encima de 40
    public float damageMultiplierAbove20 = 3f; // Multiplicador de daño cuando la vida está por debajo de 20

    [Header("Configuración de Game Over")]
    public string gameOverSceneName = "gameover"; // Nombre de la escena de Game Over

    private void Start()
    {
        currentHealth = maxHealth; // Inicializa la vida del jugador
        UpdateHealthUI(); // Actualiza la UI al iniciar
    }

    private void OnCollisionEnter(Collision collision)
    {
        TakeDamage(); // Reduce vida al chocar con cualquier objeto
    }

    void TakeDamage()
    {
        float damageToApply = damageAmount; // Inicializa el daño normal

        // Verifica el estado de vida y ajusta el daño
        if (currentHealth < 40 && currentHealth >= 20)
        {
            damageToApply *= damageMultiplierAbove40; // Duplica el daño si la vida está entre 20 y 40
        }
        else if (currentHealth < 20)
        {
            damageToApply *= damageMultiplierAbove20; // Triplica el daño si la vida está por debajo de 20
        }

        currentHealth -= damageToApply; // Reduce la vida
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Evita que la vida sea negativa
            GameOver(); // Llama al método de Game Over
        }
        UpdateHealthUI(); // Actualiza la UI después de recibir daño
    }

    void UpdateHealthUI()
    {
        healthText.text = "Vida: " + currentHealth.ToString("0"); // Actualiza el texto con la vida actual
    }

    void GameOver()
    {
        // Cambia a la escena de Game Over
        SceneManager.LoadScene(gameOverSceneName); // Cambia a la escena usando el nombre proporcionado
    }
}
