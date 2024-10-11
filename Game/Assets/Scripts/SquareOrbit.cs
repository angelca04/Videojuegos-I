using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareOrbit : MonoBehaviour
{
    // Objeto al que se orbitará (centro del cuadrado)
    public Transform target;

    // Distancia al centro (lados del cuadrado)
    public float orbitRadius = 5f;

    // Velocidad de desplazamiento
    public float orbitSpeed = 2f;

    // Variables internas para controlar el tiempo y el punto actual
    private Vector3[] squarePoints;
    private int currentPoint = 0;
    private float timeToNextPoint;
    
    void Start()
    {
        // Definir los 4 puntos del cuadrado en base al radio
        squarePoints = new Vector3[]
        {
            new Vector3(orbitRadius, 0, orbitRadius),
            new Vector3(orbitRadius, 0, -orbitRadius),
            new Vector3(-orbitRadius, 0, -orbitRadius),
            new Vector3(-orbitRadius, 0, orbitRadius)
        };

        // Calcular el tiempo para moverse entre los puntos
        timeToNextPoint = Vector3.Distance(squarePoints[0], squarePoints[1]) / orbitSpeed;

        // Iniciar en el primer punto
        transform.position = squarePoints[0] + target.position;
    }

    void Update()
    {
        // Moverse hacia el siguiente punto
        transform.position = Vector3.MoveTowards(transform.position, squarePoints[currentPoint] + target.position, orbitSpeed * Time.deltaTime);

        // Si ha llegado al punto actual, cambiar al siguiente
        if (Vector3.Distance(transform.position, squarePoints[currentPoint] + target.position) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % squarePoints.Length;
        }
    }
}