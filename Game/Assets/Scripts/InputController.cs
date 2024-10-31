using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Joystick JoystickMove;
    public Rigidbody2D rb;
    public float speed = 5f;
    bool jump;


    private void Start()
    {
        // No es necesario configurar la cámara en 2D
    }

    void Move()
    {
        // Movimiento en el plano X e Y (2D)
        rb.velocity = new Vector2(JoystickMove.Horizontal * speed + Input.GetAxis("Horizontal"), JoystickMove.Vertical * speed + Input.GetAxis("Vertical"));
    }

    private void Update()
    {
        Move();
    }
}
