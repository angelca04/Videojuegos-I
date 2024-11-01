using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerV2 : MonoBehaviour // Cambié el nombre de la clase
{
    public GameObject obstaclePrefab; // Prefab del obstáculo
    public Transform spawnPoint; // Punto de spawn del obstáculo
    public float spawnInterval = 2f; // Intervalo de spawn en segundos
    public float obstacleSpeed = 5f; // Velocidad del obstáculo

    private void Start()
    {
        // Repetir la función SpawnNewObstacle cada 'spawnInterval' segundos
        InvokeRepeating("SpawnNewObstacle", 0f, spawnInterval);
    }

    void SpawnNewObstacle()
    {
        // Instanciar el obstáculo en el punto de spawn
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPoint.position, spawnPoint.rotation);
        
        // Inicializar el movimiento del obstáculo con la velocidad especificada
        obstacle.GetComponent<ObstacleMovement>().Initialize(obstacleSpeed);
    }
}
