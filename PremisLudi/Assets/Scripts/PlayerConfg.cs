using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float speed = 5f;

    private float horizontalMove = 0;
    private float verticalMove = 0;

    public Animator animator;
    private Rigidbody2D myRigidbody2D;
    public Joystick joystick;

    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtener la entrada del joystick
        verticalMove = joystick.Vertical;
        horizontalMove = joystick.Horizontal;

        // A�adir entrada del teclado WASD
        if (Input.GetKey(KeyCode.W)) verticalMove = 1;
        else if (Input.GetKey(KeyCode.S)) verticalMove = -1;
        else verticalMove = 0;

        if (Input.GetKey(KeyCode.A)) horizontalMove = -1;
        else if (Input.GetKey(KeyCode.D)) horizontalMove = 1;
        else horizontalMove = 0;

        // Crear un vector de movimiento normalizado
        Vector2 movement = new Vector2(horizontalMove, verticalMove).normalized;

        // Mover el personaje
        MoveCharacter(movement);

        // Actualizar la animaci�n
        UpdateAnimation(movement);
    }

    private void MoveCharacter(Vector2 movement)
    {
        // Aplicar movimiento
        Vector2 newPosition = myRigidbody2D.position + movement * speed * Time.fixedDeltaTime;
        myRigidbody2D.MovePosition(newPosition);
    }

    private void UpdateAnimation(Vector2 movement)
    {
        // Actualizar los par�metros en el Animator
        animator.SetFloat("HorizontalSpeed", horizontalMove);
        animator.SetFloat("VerticalSpeed", verticalMove);

        // Determinar si el personaje se est� moviendo en diagonal
        if (Mathf.Abs(horizontalMove) > 0.1f && Mathf.Abs(verticalMove) > 0.1f)
        {
            // Mantener la animaci�n lateral (cambiar a la animaci�n horizontal)
            if (Mathf.Abs(horizontalMove) >= Mathf.Abs(verticalMove))
            {
                animator.SetFloat("HorizontalSpeed", horizontalMove);
                animator.SetFloat("VerticalSpeed", 0);
            }
            else
            {
                animator.SetFloat("VerticalSpeed", verticalMove);
                animator.SetFloat("HorizontalSpeed", 0);
            }
        }
        else
        {
            // Actualizar normalmente si no hay diagonal
            animator.SetFloat("HorizontalSpeed", horizontalMove);
            animator.SetFloat("VerticalSpeed", verticalMove);
        }
    }
}
