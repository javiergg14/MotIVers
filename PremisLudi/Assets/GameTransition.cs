using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTransition : MonoBehaviour
{
    public GameObject panelToShow; // Panel que se mostrará
    public GameObject panelToHide; // Panel que se ocultará

    // Start is called before the first frame update
    void Start()
    {
        // Asegúrate de que ambos paneles estén en el estado inicial deseado
        if (panelToShow != null)
        {
            panelToShow.SetActive(false); // Desactivar el panel a mostrar inicialmente
        }

        if (panelToHide != null)
        {
            panelToHide.SetActive(true); // Activar el panel a ocultar inicialmente
        }
    }

    // Update is called once por frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene("Game");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Alternar entre los paneles al presionar Escape
            if (panelToShow != null && panelToHide != null)
            {
                if (panelToShow.activeSelf)
                {
                    // Si el panel a mostrar está activo, ocúltalo y muestra el panel a ocultar
                    panelToShow.SetActive(false); // Ocultar el panel a mostrar
                    panelToHide.SetActive(true); // Mostrar el panel a ocultar
                }
                else
                {
                    // Si el panel a ocultar está activo, ocúltalo y muestra el panel a mostrar
                    panelToHide.SetActive(false); // Ocultar el panel a ocultar
                    panelToShow.SetActive(true); // Mostrar el panel a mostrar
                }
            }
        }
    }

    // Método que se llamará desde el botón del nuevo panel
    public void ReturnToOriginalPanel()
    {
        if (panelToShow != null && panelToHide != null)
        {
            panelToShow.SetActive(false); // Ocultar el panel a mostrar
            panelToHide.SetActive(true); // Mostrar el panel a ocultar
        }
    }
}
