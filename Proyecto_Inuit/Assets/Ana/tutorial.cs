using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject tut;
    public GameObject paso1;
    public GameObject paso2;
    public GameObject paso3;

    private void Start()
    {
        int tutor = PlayerPrefs.GetInt("Partida_nueva", 1);
        if (tutor == 1)
        {
            tut.SetActive(true);
            paso1.SetActive(true);
            paso2.SetActive(false);
            paso3.SetActive(false);
            PlayerPrefs.SetInt("Partida_nueva", 0);
            PlayerPrefs.Save();
        }

    }

    public void pasoDos()
    {
        paso2.SetActive(true);
        paso1.SetActive(false);
        
    }

    public void pasoTres()
    {
        paso3.SetActive(true);
        paso2.SetActive(false);
    }

    public void finTutorial()
    {
        paso3.SetActive(false);
        tut.SetActive(false);
    }
}
