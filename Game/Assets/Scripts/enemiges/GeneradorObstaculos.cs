using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObstaculos : MonoBehaviour
{
    public GameObject prefabObstaculo; // Prefab del obstáculo a instanciar
    public Transform puntoGeneracion; // Punto donde se generarán los obstáculos
    public float intervaloGeneracion = 2.0f; // Intervalo en segundos entre cada generación de obstáculos

    private void Start()
    {
        InvokeRepeating("GenerarObstaculo", 0, intervaloGeneracion);
    }

    private void GenerarObstaculo()
    {
        Instantiate(prefabObstaculo, puntoGeneracion.position, puntoGeneracion.rotation);
    }
}

