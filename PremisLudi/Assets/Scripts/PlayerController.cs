using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour // Cambia el nombre de la clase
{
    public float speed = 5f;
    public Animator animator;

    public float maxTiltAngle = 10f; // Ángulo máximo permitido antes de "doblarse"

   

    void Update()
    {
        // Movimiento
        float speedX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float speedY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        animator.SetFloat("movementX", speedX * speed);
        animator.SetFloat("movementY", speedY * speed);

        // Actualiza la posición del objeto
        Vector3 posicion = transform.position;
        transform.position = new Vector3(speedX + posicion.x, speedY + posicion.y, posicion.z);
    }

 
}





