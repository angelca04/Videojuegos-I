using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    // Puntos A y B (asignados en el Inspector)
    public Transform pointA;
    public Transform pointB;

    // Velocidad de movimiento
    public float speed = 5f;

    // Booleano para determinar si está yendo de A a B o de B a A
    private bool movingToB = true;

    void Update()
    {
        // Determinar el objetivo actual (punto A o punto B)
        Transform target = movingToB ? pointB : pointA;

        // Mover el objeto hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Comprobar si ha llegado al punto objetivo
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // Si llega a B, cambiar dirección hacia A y viceversa
            movingToB = !movingToB;
        }
    }
}