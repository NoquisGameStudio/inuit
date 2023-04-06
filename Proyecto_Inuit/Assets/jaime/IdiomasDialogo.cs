using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IdiomasDialogo : MonoBehaviour
{
    private int ingles;
    public string ING;
    public string ESP;
    
    // Start is called before the first frame update
    void Start()
    {
        ingles = PlayerPrefs.GetInt("Idioma", 0);
        switch (ingles)
        {
            case 0:
                transform.GetComponent<TextMeshProUGUI>().text = ING;
                break;
            case 1:
                transform.GetComponent<TextMeshProUGUI>().text  = ESP;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ingles = PlayerPrefs.GetInt("Idioma", 0);
        switch (ingles)
        {
            case 0:
                transform.GetComponent<TextMeshProUGUI>().text = ING;
                break;
            case 1:
                transform.GetComponent<TextMeshProUGUI>().text  = ESP;
                break;
        }
    }
}
