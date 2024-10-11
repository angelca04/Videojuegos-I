using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBetweenPoints : MonoBehaviour
{
    // Puntos A y B (asignados en el Inspector)
    public Transform pointA;
    public Transform pointB;

    // Velocidad de movimiento
    public float speed = 5f;

    void Update()
    {
        // Mover el objeto hacia el punto B
        transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);

        // Cuando llega al punto B, reinicia en el punto A
        if (Vector3.Distance(transform.position, pointB.position) < 0.1f)
        {
            // Reiniciar la posición en el punto A
            transform.position = pointA.position;
        }
    }
}