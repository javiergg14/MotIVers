using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private Vector3 targetPosition;   // Almacena la posici�n objetivo
    private bool isMoving = false;    // Controla si el objeto se est� moviendo
    public float speed = 5f;          // Velocidad de movimiento del objeto

    // Update is called once per frame
    void Update()
    {
        // Detectar clic izquierdo en cualquier parte de la pantalla
        if (Input.GetMouseButtonDown(0))
        {
            // Convertir la posici�n del rat�n a coordenadas del mundo
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            targetPosition = new Vector3(mousePos.x, mousePos.y, transform.position.z);  // Establecer la posici�n objetivo

            isMoving = true;  // Activar el movimiento hacia la posici�n del clic
        }

        // Si el objeto est� en movimiento, interpola hacia la posici�n objetivo
        if (isMoving)
        {
            // Mueve el objeto hacia la posici�n objetivo usando Lerp para interpolaci�n suave
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

            // Si el objeto est� lo suficientemente cerca del objetivo, detenemos el movimiento
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;  // Detener el movimiento una vez llega al objetivo
            }
        }
    }
}

