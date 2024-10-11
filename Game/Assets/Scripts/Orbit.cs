using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orbit : MonoBehaviour
{
    // Objeto al que se orbitará (centro del círculo)
    public Transform target;

    // Distancia al centro (radio de la órbita)
    public float orbitRadius = 5f;

    // Velocidad angular en grados por segundo
    public float orbitSpeed = 30f;

    // Ejes para definir el plano de la órbita (pueden modificarse desde el Inspector)
    public Vector3 orbitAxis = Vector3.up;

    void Update()
    {
        if (target != null)
        {
            // Rotar alrededor del objeto objetivo (target)
            transform.RotateAround(target.position, orbitAxis, orbitSpeed * Time.deltaTime);

            // Mantener la distancia del radio desde el objeto objetivo
            Vector3 desiredPosition = (transform.position - target.position).normalized * orbitRadius + target.position;
            transform.position = desiredPosition;
        }
    }
}