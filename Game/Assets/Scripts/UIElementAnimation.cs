using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementAnimation : MonoBehaviour
{
    [Header("Configuraciones de Movimiento")]
    [SerializeField] private float amplitude = 10f; // Amplitud del movimiento (intensidad)
    [SerializeField] private float frequency = 1f; // Frecuencia del movimiento (velocidad)

    private Vector3 initialPosition;

    private void Start()
    {
        // Guardamos la posición inicial del elemento
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        // Aplicamos un movimiento oscilatorio en el eje Y
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = initialPosition + new Vector3(0, yOffset, 0);
    }
}

