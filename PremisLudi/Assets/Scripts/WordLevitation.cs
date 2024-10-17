using System.Collections;
using UnityEngine;

public class WordLevitation : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    // Variables para sacudidas
    private float agitationAngle = 10f;          // �ngulo de sacudida en grados
    private float agitationDuration = 0.1f;      // Duraci�n de cada sacudida
    private float agitationCooldown = 0.1f;      // Tiempo de espera entre sacudidas
    private float pauseBetweenAgitations = 2f;   // Tiempo de espera entre grupos de sacudidas
    private int agitationRepeats = 5;            // N�mero de repeticiones de la sacudida
    private Quaternion originalRotation;         // Rotaci�n original para referencia

    private float nextAgitationTime = 0f;        // Tiempo en que se puede realizar la pr�xima sacudida
    private int currentAgitationCount = 0;       // Contador de sacudidas actuales
    private bool isAgitating = false;            // Indica si est� realizando sacudidas
    private bool isPlayerInRange = false;        // Indica si el jugador est� en el rango de levitaci�n
    private bool stopAgitationRequested = false; // Indica si se ha solicitado detener la agitaci�n

    // Variable que indica si est� siendo sostenida
    private bool isHeld = false;

    private void Start()
    {
        originalRotation = transform.rotation;    // Guardar la rotaci�n original
    }

    private void Update()
    {
        // Comprobar si el jugador est� dentro de la distancia de levitaci�n
        float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        isPlayerInRange = distanceToPlayer <= 4f; // Distancia de interacci�n

        // Si el objeto est� siendo sostenido, permitir el movimiento pero no la rotaci�n
        if (isHeld)
        {
            return; // No hacer nada m�s si la palabra est� sostenida
        }

        // Manejo de las sacudidas si el jugador est� dentro del rango
        if (isPlayerInRange && !isAgitating && Time.time >= nextAgitationTime)
        {
            stopAgitationRequested = false; // Resetear si el jugador ha vuelto a estar en rango
            StartCoroutine(AgitateWord());
        }
        else if (!isPlayerInRange && isAgitating)
        {
            // Si el jugador sale del rango mientras est� agitando, marcar para detener la agitaci�n despu�s
            stopAgitationRequested = true;
        }
    }

    private IEnumerator AgitateWord()
    {
        isAgitating = true; // Cambiar el estado a agitando
        currentAgitationCount = 0; // Reiniciar el contador de sacudidas

        while (currentAgitationCount < agitationRepeats)
        {
            StartAgitation(currentAgitationCount % 2 == 0); // Rotar a la derecha o a la izquierda
            yield return new WaitForSeconds(agitationCooldown); // Esperar entre sacudidas

            // Si se ha solicitado detener la agitaci�n y estamos fuera de rango, finalizar
            if (stopAgitationRequested && !isPlayerInRange)
            {
                break;
            }

            currentAgitationCount++;
        }

        // Restablecer la rotaci�n al finalizar las sacudidas o al salir del rango
        yield return RotateToOriginalPosition(0.5f); // Suavizar la transici�n a la rotaci�n original

        // Esperar un tiempo despu�s de completar las sacudidas si no se ha solicitado detener
        if (!stopAgitationRequested)
        {
            yield return new WaitForSeconds(pauseBetweenAgitations);
            nextAgitationTime = Time.time; // Reiniciar el tiempo para la pr�xima serie de sacudidas
        }

        isAgitating = false; // Resetear el estado de agitaci�n
    }

    private IEnumerator RotateToOriginalPosition(float duration)
    {
        float elapsedTime = 0f;

        Quaternion startingRotation = transform.rotation;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(startingRotation, originalRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = originalRotation; // Asegurarse de que la rotaci�n final se establezca correctamente
    }

    private void StartAgitation(bool toRight)
    {
        // Rotar hacia la derecha o izquierda basado en el par�metro
        float targetAngle = toRight ? agitationAngle : -agitationAngle;
        // Realizar la rotaci�n suave durante la duraci�n especificada
        StartCoroutine(RotateOverTime(targetAngle, agitationDuration));
    }

    private IEnumerator RotateOverTime(float targetAngle, float duration)
    {
        float elapsedTime = 0f;
        Quaternion initialRotation = transform.rotation;
        Quaternion finalRotation = Quaternion.Euler(0, 0, targetAngle);

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(initialRotation, finalRotation, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.rotation = finalRotation; // Asegurarse de que la rotaci�n final se establezca correctamente
    }

    // Llamar este m�todo cuando se cargue la palabra (llamarlo desde el script de interacci�n)
    public void SetHeld(bool held)
    {
        isHeld = held;

        // Si se suelta, no permitir que la palabra rote y restaurar la rotaci�n si no est� en rango
        if (!isHeld && !isPlayerInRange)
        {
            transform.rotation = originalRotation;
        }
    }
}
