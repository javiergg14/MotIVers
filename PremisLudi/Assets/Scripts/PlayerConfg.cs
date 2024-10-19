using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float speed = 5f;

    private float horizontalMove = 0;
    private float verticalMove = 0;

    public Animator animator;
    private Rigidbody2D rigidbody2D;
    public Joystick joystick;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtener la entrada del joystick
        verticalMove = joystick.Vertical;
        horizontalMove = joystick.Horizontal;

        // Crear un vector de movimiento normalizado
        Vector2 movement = new Vector2(horizontalMove, verticalMove).normalized;

        // Mover el personaje
        MoveCharacter(movement);

        // Actualizar la animación
        UpdateAnimation(movement);
    }

    private void MoveCharacter(Vector2 movement)
    {
        // Aplicar movimiento
        Vector2 newPosition = rigidbody2D.position + movement * speed * Time.fixedDeltaTime;
        rigidbody2D.MovePosition(newPosition);
    }

    private void UpdateAnimation(Vector2 movement)
    {
        // Actualizar los parámetros en el Animator
        animator.SetFloat("HorizontalSpeed", horizontalMove);
        animator.SetFloat("VerticalSpeed", verticalMove);

        // Determinar si el personaje se está moviendo en diagonal
        if (Mathf.Abs(horizontalMove) > 0.1f && Mathf.Abs(verticalMove) > 0.1f)
        {
            // Mantener la animación lateral (cambiar a la animación horizontal)
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
