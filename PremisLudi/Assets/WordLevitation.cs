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
    private Vector3 originalScale;               // Escala original para referencia
    private Quaternion originalRotation;         // Rotaci�n original para referencia

    private float nextAgitationTime = 0f;        // Tiempo en que se puede realizar la pr�xima sacudida
    private int currentAgitationCount = 0;       // Contador de sacudidas actuales
    private bool isAgitating = false;            // Indica si est� realizando sacudidas
    private bool isPlayerInRange = false;        // Indica si el jugador est� en el rango de levitaci�n

    private void Start()
    {
        originalScale = transform.localScale;     // Guardar la escala original
        originalRotation = transform.rotation;    // Guardar la rotaci�n original
    }

    private void Update()
    {
        // Comprobar si el jugador est� dentro de la distancia de levitaci�n
        float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        isPlayerInRange = distanceToPlayer <= 4f; // Distancia de interacci�n

        // Manejo de las sacudidas si el jugador est� dentro del rango
        if (isPlayerInRange && !isAgitating && Time.time >= nextAgitationTime)
        {
            StartCoroutine(AgitateWord());
        }
        else if (!isPlayerInRange)
        {
            // Restablecer la rotaci�n al salir del rango
            transform.rotation = originalRotation;
            currentAgitationCount = 0; // Reiniciar el contador
            isAgitating = false; // Resetear el estado de agitaci�n
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
            currentAgitationCount++;
        }

        // Restablecer la rotaci�n al finalizar las sacudidas
        yield return RotateToOriginalPosition(0.5f); // Suavizar la transici�n a la rotaci�n original

        // Esperar un tiempo despu�s de completar las sacudidas
        yield return new WaitForSeconds(pauseBetweenAgitations);
        nextAgitationTime = Time.time; // Reiniciar el tiempo para la pr�xima serie de sacudidas
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
}
