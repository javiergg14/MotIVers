using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public Animator animator; // Referencia al componente Animator

    void Update()
    {
        // Obtener el input de los ejes horizontal y vertical
        float speedX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float speedY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // Configurar el par�metro de animaci�n "movement" seg�n el valor de la velocidad horizontal
        animator.SetFloat("movementX", speedX * speed);
        animator.SetFloat("movementY", speedY * speed);


        // Obtener la posici�n actual
        Vector3 posicion = transform.position;

        // Actualizar la posici�n en los ejes X y Y (movimiento horizontal y vertical)
        transform.position = new Vector3(speedX + posicion.x, speedY + posicion.y, posicion.z);
    }
}


