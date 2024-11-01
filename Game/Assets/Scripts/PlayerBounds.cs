using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; // Obtiene la cámara principal
    }

    private void Update()
    {
        // Obtiene las posiciones de los límites de la pantalla
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        Vector2 playerPos = transform.position;

        // Restringe el movimiento del jugador dentro de los límites
        playerPos.x = Mathf.Clamp(playerPos.x, -screenBounds.x, screenBounds.x);
        playerPos.y = Mathf.Clamp(playerPos.y, -screenBounds.y, screenBounds.y);

        // Actualiza la posición del jugador
        transform.position = playerPos;
    }
}

