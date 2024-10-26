using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class LogicaBrillo : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelBrillo;

    // Start is called before the first frame update
    void Start()
    {
        // Cargar el valor del brillo, manteniendo el valor invertido
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        UpdatePanelBrillo(slider.value);
    }

    // Método para actualizar el color del panel según el brillo
    private void UpdatePanelBrillo(float brightness)
    {
        // Invertir el valor para el brillo
        float invertedBrightness = 1 - brightness;
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, invertedBrightness);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        UpdatePanelBrillo(sliderValue);
    }
}
