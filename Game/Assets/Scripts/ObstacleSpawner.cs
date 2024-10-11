using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Prefab del obstáculo o enemigo a generar (asignado desde el Inspector)
    public GameObject obstaclePrefab;

    // Velocidad de los objetos al moverse de derecha a izquierda
    public float obstacleSpeed = 5f;

    // Rango de altura en que los objetos aparecerán
    public float minY = -3f;
    public float maxY = 3f;

    // Posición en el eje X para generar los obstáculos fuera de la vista (a la derecha de la cámara)
    private float spawnXPosition;

    // Referencia al obstáculo actual
    private GameObject currentObstacle;

    // Tiempo que un obstáculo permanecerá en pantalla antes de destruirse
    public float obstacleLifetime = 5f;

    void Start()
    {
        // Calcular la posición de generación en el eje X fuera de la vista de la cámara
        Camera mainCamera = Camera.main;
        spawnXPosition = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 2f;
    }

    void Update()
    {
        // Generar un nuevo obstáculo solo si no hay ninguno actual
        if (currentObstacle == null)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        // Generar un obstáculo en una posición aleatoria en Y
        float spawnYPosition = Random.Range(minY, maxY);

        // Crear el obstáculo en la posición de spawn y guardarlo en currentObstacle
        currentObstacle = Instantiate(obstaclePrefab, new Vector3(spawnXPosition, spawnYPosition, 0), Quaternion.identity);

        // Asignar el script para mover el obstáculo y establecer su velocidad y vida útil
        MoveObstacle moveScript = currentObstacle.AddComponent<MoveObstacle>();
        moveScript.SetSpeed(obstacleSpeed);
        moveScript.SetLifetime(obstacleLifetime); // Añadir la duración antes de destruirlo
    }
}

public class MoveObstacle : MonoBehaviour
{
    // Velocidad de movimiento del obstáculo
    private float speed;

    // Posición límite en X para destruir el obstáculo cuando salga de la pantalla
    private float destroyXPosition;

    // Tiempo que el obstáculo vivirá antes de ser destruido
    private float lifetime;

    void Start()
    {
        // Calcular el límite de la cámara en el lado izquierdo
        Camera mainCamera = Camera.main;
        destroyXPosition = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - 2f;
    }

    public void SetSpeed(float obstacleSpeed)
    {
        speed = obstacleSpeed;
    }

    public void SetLifetime(float obstacleLifetime)
    {
        lifetime = obstacleLifetime;
    }

    void Update()
    {
        // Mover el obstáculo hacia la izquierda
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Destruir el obstáculo cuando salga del límite izquierdo de la pantalla
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }

        // Destruir el obstáculo después de que pase el tiempo de vida
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}