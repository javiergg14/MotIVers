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
        float joystickVertical = joystick.Vertical;
        float joystickHorizontal = joystick.Horizontal;

        // Manejar la entrada de teclado (WASD)
        HandleKeyboardInput();

        // Combinar la entrada del joystick y del teclado
        horizontalMove = joystickHorizontal + (Input.GetKey(KeyCode.D) ? 1f : 0) + (Input.GetKey(KeyCode.A) ? -1f : 0);
        verticalMove = joystickVertical + (Input.GetKey(KeyCode.W) ? 1f : 0) + (Input.GetKey(KeyCode.S) ? -1f : 0);

        // Crear un vector de movimiento normalizado
        Vector2 movement = new Vector2(horizontalMove, verticalMove).normalized;

        // Mover el personaje
        MoveCharacter(movement);

        // Actualizar la animación
        UpdateAnimation(movement);
    }

    private void HandleKeyboardInput()
    {
        // Este método ahora se puede quitar, ya que se maneja la entrada de teclado en Update.
    }

    private void MoveCharacter(Vector2 movement)
    {
        // Aplicar movimiento
        Vector2 newPosition = myRigidbody2D.position + movement * speed * Time.fixedDeltaTime;
        myRigidbody2D.MovePosition(newPosition);
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
