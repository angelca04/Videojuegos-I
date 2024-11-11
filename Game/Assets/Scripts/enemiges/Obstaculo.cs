using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float velocidad = 5.0f; // Velocidad a la que se mueve el obstáculo
    public float tiempoDesaparicion = 10.0f; // Tiempo en segundos antes de que el obstáculo desaparezca
    public GameObject prefabExplosion; // Prefab de la explosión

    private void Start()
    {
        Destroy(gameObject, tiempoDesaparicion); // Destruye el obstáculo después de un tiempo
    }

    private void Update()
    {
        // Mover el obstáculo en línea recta
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision colision)
    {
        // Si choca con algo, libera la explosión y destruye el obstáculo
        if (prefabExplosion != null)
        {
            Instantiate(prefabExplosion, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}

