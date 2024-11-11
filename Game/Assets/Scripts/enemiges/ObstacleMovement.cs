using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public GameObject explosionEffectPrefab; // Prefab de la explosión
    public float speed = 5f; // Velocidad del obstáculo, editable desde el Inspector

    void Start()
    {
        // Generar una velocidad aleatoria siempre por encima de 580
        speed = Random.Range(580f, 1000f); // Ajusta el rango máximo según sea necesario
    }

    void Update()
    {
        // Mover el obstáculo en línea recta (usando el eje local)
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
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


