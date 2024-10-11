using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTextura : MonoBehaviour
{
    public float velocidad = 0.1f; // Velocidad del desplazamiento
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Obtener el desplazamiento
        float desplazamiento = Time.time * velocidad;

        // Desplazar la textura en el eje X o Y según quieras
        renderer.material.SetTextureOffset("_MainTex", new Vector2(desplazamiento, 0));
    }
}