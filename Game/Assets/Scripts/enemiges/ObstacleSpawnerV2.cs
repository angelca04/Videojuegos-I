using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerV2 : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab del obstáculo
    public Transform spawnPoint; // Punto de spawn del obstáculo
    public float spawnInterval = 2f; // Intervalo de spawn en segundos
    public int maxObstacles = 2; // Máximo de obstáculos en pantalla
    public float autoDestructionTime = 5f; // Tiempo antes de que se destruya un obstáculo sin chocar

    private List<GameObject> activeObstacles = new List<GameObject>(); // Lista de obstáculos activos

    private void Start()
    {
        // Repetir la función SpawnObstacle cada 'spawnInterval' segundos
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Solo generar un nuevo obstáculo si no se ha alcanzado el máximo
        if (activeObstacles.Count < maxObstacles)
        {
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPoint.position, spawnPoint.rotation);
            activeObstacles.Add(obstacle); // Agregar el nuevo obstáculo a la lista

            // Iniciar la destrucción automática del obstáculo
            StartCoroutine(AutoDestruct(obstacle));
        }
    }

    // Corrutina para destruir el obstáculo después de un tiempo si no ha chocado
    private IEnumerator AutoDestruct(GameObject obstacle)
    {
        yield return new WaitForSeconds(autoDestructionTime);
        
        // Destruir el obstáculo
        Destroy(obstacle);
        activeObstacles.Remove(obstacle); // Eliminar de la lista de obstáculos activos
    }
}
