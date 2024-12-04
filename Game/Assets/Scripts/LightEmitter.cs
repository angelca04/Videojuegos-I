using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Light))]
public class LightEmitter : MonoBehaviour
{
    private Light lightComponent;

    void Awake()
    {
        // Asegurarse de que el GameObject tenga un componente Light
        lightComponent = GetComponent<Light>();
        if (lightComponent == null)
        {
            lightComponent = gameObject.AddComponent<Light>();
        }

        // Configuración de la luz
        ConfigureLight();
    }

    void ConfigureLight()
    {
        lightComponent.type = LightType.Point; // Tipo de luz
        lightComponent.range = 5f;            // Alcance de la luz
        lightComponent.intensity = 0.5f;      // Intensidad de la luz
        lightComponent.color = Color.white;   // Color de la luz

        // Opcional: Ajusta las sombras
        lightComponent.shadows = LightShadows.None; // Sin sombras para mejor rendimiento
    }
}
