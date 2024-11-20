using System.Collections;
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
    public float damageMultiplierAbove40 = 2f; // Multiplicador de daño cuando la vida está entre 20 y 40
    public float damageMultiplierAbove20 = 3f; // Multiplicador de daño cuando la vida está por debajo de 20

    [Header("Configuración de Game Over")]
    public string gameOverSceneName = "gameover"; // Nombre de la escena de Game Over

    [Header("Configuración de Sacudida")]
    public float shakeDuration = 0.2f; // Duración del efecto de sacudida
    public float shakeIntensity = 5f; // Intensidad del movimiento

    private Vector3 originalPosition; // Posición original del texto

    private void Start()
    {
        currentHealth = maxHealth; // Inicializa la vida del jugador
        originalPosition = healthText.rectTransform.localPosition; // Guarda la posición original del texto
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
        healthText.text = "HP " + currentHealth.ToString("0"); // Actualiza el texto con la vida actual
        StartCoroutine(ShakeText()); // Inicia la sacudida del texto
    }

    IEnumerator ShakeText()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // Genera una nueva posición aleatoria
            Vector3 randomOffset = Random.insideUnitSphere * shakeIntensity;
            randomOffset.z = 0; // Mantén el movimiento solo en 2D

            healthText.rectTransform.localPosition = originalPosition + randomOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Vuelve a la posición original después de la sacudida
        healthText.rectTransform.localPosition = originalPosition;
    }

    void GameOver()
    {
        // Cambia a la escena de Game Over
        SceneManager.LoadScene(gameOverSceneName); // Cambia a la escena usando el nombre proporcionado
    }
}
