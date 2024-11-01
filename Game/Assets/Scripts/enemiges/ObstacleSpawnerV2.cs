using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerV2 : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab del obstáculo
    public Transform spawnPoint; // Punto de spawn del obstáculo
    public float spawnInterval = 2f; // Intervalo de spawn en segundos

    private void Start()
    {
        // Repetir la función SpawnObstacle cada 'spawnInterval' segundos
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPoint.position, spawnPoint.rotation);
        // Aquí puedes configurar propiedades adicionales del obstáculo si es necesario
        ObstacleMovement movementScript = obstacle.GetComponent<ObstacleMovement>();
        if (movementScript != null)
        {
            movementScript.Initialize(5f); // Puedes ajustar la velocidad deseada
        }
    }
}
