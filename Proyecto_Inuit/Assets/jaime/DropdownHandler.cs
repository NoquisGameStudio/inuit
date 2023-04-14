using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    private TMP_Dropdown dropdown;

    private void Start()
    {
        dropdown = transform.GetComponent<TMP_Dropdown>();

        dropdown.options.Clear(); // Elimina las opciones predeterminadas

        // Agrega las opciones "Español" e "Inglés"
        dropdown.options.Add(new TMP_Dropdown.OptionData("English"));
        dropdown.options.Add(new TMP_Dropdown.OptionData("Español"));

        // Establece la opción predeterminada como "english"
        dropdown.value = 0;
        dropdown.RefreshShownValue();

        // Asigna la función correspondiente a cada opción
        dropdown.onValueChanged.AddListener(delegate
        {
            CambiarIdioma(dropdown);
        });
    }

    void CambiarIdioma(TMP_Dropdown cambio)
    {
        if (cambio.value == 0)
        {
            // Ejecutar función para cambiar a english
            PlayerPrefs.SetInt("Idioma", 0);
            PlayerPrefs.Save();
        }
        else if (cambio.value == 1)
        {
            // Ejecutar función para cambiar a español
            PlayerPrefs.SetInt("Idioma", 1);
            PlayerPrefs.Save();
        }
        
        Debug.Log("Cambio a idioma: " + PlayerPrefs.GetInt("Idioma"));
    }
}
