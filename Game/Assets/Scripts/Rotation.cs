using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    
    // Velocidad de rotacion 
    public float rotationSpeed = 10f;
    void Update()
    {
        //Rotar en su propio eje
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        
    }
}
