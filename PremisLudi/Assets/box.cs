using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private Vector3 targetPosition;   // Almacena la posición objetivo
    private bool isMoving = false;    // Controla si el objeto se está moviendo
    public float speed = 5f;          // Velocidad de movimiento del objeto

    // Update is called once per frame
    void Update()
    {
        // Detectar clic izquierdo en cualquier parte de la pantalla
        if (Input.GetMouseButtonDown(0))
        {
            // Convertir la posición del ratón a coordenadas del mundo
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            targetPosition = new Vector3(mousePos.x, mousePos.y, transform.position.z);  // Establecer la posición objetivo

            isMoving = true;  // Activar el movimiento hacia la posición del clic
        }

        // Si el objeto está en movimiento, interpola hacia la posición objetivo
        if (isMoving)
        {
            // Mueve el objeto hacia la posición objetivo usando Lerp para interpolación suave
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

            // Si el objeto está lo suficientemente cerca del objetivo, detenemos el movimiento
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;  // Detener el movimiento una vez llega al objetivo
            }
        }
    }
}

