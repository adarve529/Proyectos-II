using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject John;
    public float cameraFollowSpeed; // Velocidad de seguimiento de la cámara
    public float verticalMargin; // Margen vertical para activar el seguimiento

    // Update is called once per frame
    void Update()
    {
        if (John != null)
        {
            // Obtener la posición actual de la cámara
            Vector3 targetPosition = transform.position;

            // Seguir a John en el eje X
            targetPosition.x = John.transform.position.x;

            // Solo sigue al personaje en el eje Y si está cerca del borde vertical
            float verticalDifference = John.transform.position.y - transform.position.y;
            if (Mathf.Abs(verticalDifference) > verticalMargin)
            {
                targetPosition.y = John.transform.position.y;
            }

            // Interpolar suavemente la posición de la cámara
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraFollowSpeed);
        }
    }
}
