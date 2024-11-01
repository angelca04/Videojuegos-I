using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Joystick JoystickMove; // El joystick para el movimiento
    public Rigidbody rb; // Rigidbody 3D
    public float speed = 5f;

    void Move()
    {
        // Obtener el valor vertical del joystick
        float verticalMovement = JoystickMove.Vertical; // Movimiento vertical
        Vector3 movement = new Vector3(0f, verticalMovement, 0f); // Solo movimiento en el eje Y

        // Aplicar la velocidad al Rigidbody
        rb.velocity = movement * speed; // Actualiza la velocidad del Rigidbody
    }

    private void Update()
    {
        Move();
    }
}
