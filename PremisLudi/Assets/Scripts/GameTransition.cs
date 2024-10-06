using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTransition : MonoBehaviour
{
    public GameObject panelToShow; // Panel que se mostrar�
    public GameObject panelToHide; // Panel que se ocultar�

    // Start is called before the first frame update
    void Start()
    {
        // Aseg�rate de que ambos paneles est�n en el estado inicial deseado
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
                    // Si el panel a mostrar est� activo, oc�ltalo y muestra el panel a ocultar
                    panelToShow.SetActive(false); // Ocultar el panel a mostrar
                    panelToHide.SetActive(true); // Mostrar el panel a ocultar
                }
                else
                {
                    // Si el panel a ocultar est� activo, oc�ltalo y muestra el panel a mostrar
                    panelToHide.SetActive(false); // Ocultar el panel a ocultar
                    panelToShow.SetActive(true); // Mostrar el panel a mostrar
                }
            }
        }
    }

    // M�todo que se llamar� desde el bot�n del nuevo panel
    public void ReturnToOriginalPanel()
    {
        if (panelToShow != null && panelToHide != null)
        {
            panelToShow.SetActive(false); // Ocultar el panel a mostrar
            panelToHide.SetActive(true); // Mostrar el panel a ocultar
        }
    }
}
