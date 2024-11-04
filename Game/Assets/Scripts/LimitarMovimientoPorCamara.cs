using UnityEngine;

public class LimitarMovimientoPorCamara : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cam;
    private Vector3 minBounds; // Límites mínimos (abajo, izquierda)
    private Vector3 maxBounds; // Límites máximos (arriba, derecha)
    public float offsetSuperior = 0.5f; // Ajusta este valor según sea necesario

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;

        // Calcular los límites de la cámara en el espacio del mundo
        float zDistance = Mathf.Abs(cam.transform.position.z - transform.position.z); // Distancia fija en Z

        minBounds = cam.ViewportToWorldPoint(new Vector3(0, 0, zDistance));  // Esquina inferior izquierda
        maxBounds = cam.ViewportToWorldPoint(new Vector3(1, 1, zDistance));  // Esquina superior derecha

        // Aplicar offset al límite superior
        maxBounds.y -= offsetSuperior; // Ajusta este valor según sea necesario
    }

    void Update()
    {
        // Obtener la posición actual del personaje
        Vector3 pos = transform.position;

        // Limitar la posición del personaje para que no salga de los límites de la cámara
        pos.x = Mathf.Clamp(pos.x, minBounds.x, maxBounds.x); // Limita el movimiento en el eje X
        pos.y = Mathf.Clamp(pos.y, minBounds.y, maxBounds.y); // Limita el movimiento en el eje Y

        // Aplicar la nueva posición al personaje
        transform.position = pos;

        // Si llega al límite en Y, detener su movimiento en ese eje
        if (pos.y <= minBounds.y || pos.y >= maxBounds.y)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Detiene el movimiento en Y
        }
    }
}
