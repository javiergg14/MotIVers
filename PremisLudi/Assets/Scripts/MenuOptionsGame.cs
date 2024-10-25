using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuManager : MonoBehaviour
{
    public GameObject settingsPanel; // Panel del men� de ajustes en esta escena

    // Start is called before the first frame update
    void Start()
    {
        // Aseg�rate de que el panel de ajustes est� desactivado al inicio
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false); // Desactivar el men� de ajustes inicialmente
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Abrir el men� de ajustes con la tecla 'K'
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (settingsPanel != null)
            {
                // Alternar la visibilidad del panel de ajustes
                settingsPanel.SetActive(!settingsPanel.activeSelf);
            }
        }
    }
}
