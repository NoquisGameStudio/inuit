using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdiomasCanvas : MonoBehaviour
{
    public GameObject[] textoING;

    public GameObject[] textoESP;

    private int ingles;
    // Start is called before the first frame update
    void Start()
    {
        ingles = PlayerPrefs.GetInt("Idioma", 0);
        if (ingles == 0)//true
        {
            foreach (GameObject texto in textoESP)
            {
                texto.SetActive(false);
            }
            foreach (GameObject texto in textoING)
            {
                texto.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject texto in textoESP)
            {
                texto.SetActive(true);
            }
            foreach (GameObject texto in textoING)
            {
                texto.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ingles = PlayerPrefs.GetInt("Idioma", 0);
        
        if (ingles == 0)//true
        {
            foreach (GameObject texto in textoESP)
            {
                texto.SetActive(false);
            }
            foreach (GameObject texto in textoING)
            {
                texto.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject texto in textoESP)
            {
                texto.SetActive(true);
            }
            foreach (GameObject texto in textoING)
            {
                texto.SetActive(false);
            }
        }
    }
}
