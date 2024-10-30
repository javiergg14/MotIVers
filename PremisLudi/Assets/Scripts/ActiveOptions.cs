using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // Asigna el panel desde el Inspector

    void Start()
    {
        // Aseg�rate de que el panel est� desactivado al inicio
        panel.SetActive(false);
    }

    public void TogglePanel()
    {
        // Cambia el estado del panel (visible / oculto)
        panel.SetActive(!panel.activeSelf);
    }
}