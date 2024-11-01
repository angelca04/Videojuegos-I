using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public GameObject explosionEffectPrefab; // Prefab de la explosión
    private float speed; // Velocidad del obstáculo

    // Inicializar el obstáculo con la velocidad
    public void Initialize(float obstacleSpeed)
    {
        speed = obstacleSpeed;
    }

    void Update()
    {
        // Mover el obstáculo en línea recta (eje Z)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Método que se llama automáticamente cuando el obstáculo colisiona con otro objeto
    void OnCollisionEnter(Collision collision) // Usamos Collision para 3D
    {
        // Instanciar el efecto de explosión en la posición del obstáculo
        if (explosionEffectPrefab != null) // Verifica que el prefab no sea nulo
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        // Destruir el obstáculo después de la colisión
        Destroy(gameObject);
    }
}
