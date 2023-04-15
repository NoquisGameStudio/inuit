using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MANAGER_LOBBY : MonoBehaviour
{
    public TMP_Text poder;
    
    public string[] Nombres_misiones;
    public GameObject[] GameObjects_misiones;
    string[] misiones_activas=new string[3];

    public GameObject tutorial;
    
    private void Start()
    {
        tutorial.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        int ingles = PlayerPrefs.GetInt("Idioma", 0);
        switch (ingles)
        {
            case 0:
                poder.text = "Power: " + PlayerPrefs.GetFloat("DañoPlayer");
                break;
            case 1:
                poder.text = "Poder: " + PlayerPrefs.GetFloat("DañoPlayer");
                break;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menupausa");
        }
    }

}
