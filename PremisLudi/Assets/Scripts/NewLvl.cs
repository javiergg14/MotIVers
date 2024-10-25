using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public GameObject player; // Arrastra aqu� el objeto del jugador en el inspector
    public string nombreDeLaEscena;

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que colisiona es el jugador
        if (other.gameObject == player)
        {
            Debug.Log("Colisi�n detectada con el jugador.");
            SceneManager.LoadScene(nombreDeLaEscena);
        }
    }
}


