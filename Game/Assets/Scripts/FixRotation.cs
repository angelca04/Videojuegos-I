using UnityEngine;

public class FixRotation : MonoBehaviour
{
    void Start()
    {
        // Establecer la rotación deseada del personaje al iniciar la escena
        transform.rotation = Quaternion.Euler(0, 90, 0); // Ajusta los valores según sea necesario
    }

    void Update()
    {
        // Mantener la rotación fija para evitar que se voltee al moverse
        transform.rotation = Quaternion.Euler(0, 90, 0); // Ajusta los valores según sea necesario
    }
}
