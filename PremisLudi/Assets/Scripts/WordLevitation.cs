using System.Collections;
using UnityEngine;

public class WordLevitation : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    // Variables para sacudidas
    private float agitationAngle = 10f;          // Ángulo de sacudida en grados
    private float agitationDuration = 0.1f;      // Duración de cada sacudida
    private float agitationCooldown = 0.1f;      // Tiempo de espera entre sacudidas
    private float pauseBetweenAgitations = 2f;   // Tiempo de espera entre grupos de sacudidas
    private int agitationRepeats = 5;            // Número de repeticiones de la sacudida
    private Quaternion originalRotation;         // Rotación original para referencia

    private float nextAgitationTime = 0f;        // Tiempo en que se puede realizar la próxima sacudida
    private int currentAgitationCount = 0;       // Contador de sacudidas actuales
    private bool isAgitating = false;            // Indica si está realizando sacudidas
    private bool isPlayerInRange = false;        // Indica si el jugador está en el rango de levitación
    private bool stopAgitationRequested = false; // Indica si se ha solicitado detener la agitación

    // Variable que indica si está siendo sostenida
    private bool isHeld = false;

    private void Start()
    {
        originalRotation = transform.rotation;    // Guardar la rotación original
    }

    private void Update()
    {
        // Comprobar si el jugador está dentro de la distancia de levitación
        float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        isPlayerInRange = distanceToPlayer <= 4f; // Distancia de interacción

        // Si el objeto está siendo sostenido, permitir el movimiento pero no la rotación
        if (isHeld)
        {
            return; // No hacer nada más si la palabra está sostenida
        }

        // Manejo de las sacudidas si el jugador está dentro del rango
        if (isPlayerInRange && !isAgitating && Time.time >= nextAgitationTime)
        {
            stopAgitationRequested = false; // Resetear si el jugador ha vuelto a estar en rango
            StartCoroutine(AgitateWord());
        }
        else if (!isPlayerInRange && isAgitating)
        {
            // Si el jugador sale del rango mientras está agitando, marcar para detener la agitación después
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

            // Si se ha solicitado detener la agitación y estamos fuera de rango, finalizar
            if (stopAgitationRequested && !isPlayerInRange)
            {
                break;
            }

            currentAgitationCount++;
        }

        // Restablecer la rotación al finalizar las sacudidas o al salir del rango
        yield return RotateToOriginalPosition(0.5f); // Suavizar la transición a la rotación original

        // Esperar un tiempo después de completar las sacudidas si no se ha solicitado detener
        if (!stopAgitationRequested)
        {
            yield return new WaitForSeconds(pauseBetweenAgitations);
            nextAgitationTime = Time.time; // Reiniciar el tiempo para la próxima serie de sacudidas
        }

        isAgitating = false; // Resetear el estado de agitación
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

        transform.rotation = originalRotation; // Asegurarse de que la rotación final se establezca correctamente
    }

    private void StartAgitation(bool toRight)
    {
        // Rotar hacia la derecha o izquierda basado en el parámetro
        float targetAngle = toRight ? agitationAngle : -agitationAngle;
        // Realizar la rotación suave durante la duración especificada
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
        transform.rotation = finalRotation; // Asegurarse de que la rotación final se establezca correctamente
    }

    // Llamar este método cuando se cargue la palabra (llamarlo desde el script de interacción)
    public void SetHeld(bool held)
    {
        isHeld = held;

        // Si se suelta, no permitir que la palabra rote y restaurar la rotación si no está en rango
        if (!isHeld && !isPlayerInRange)
        {
            transform.rotation = originalRotation;
        }
    }
}
