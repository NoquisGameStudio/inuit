using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mision : MonoBehaviour
{

    public Button boton;
    public TMP_Text texto;
    public string nombre_de_la_mision;


    public TMP_Text[] otros;

    public FlechaMisiones flecha;

    public bool activada_flecha = false;


    // Start is called before the first frame update
    void Start()
    {
        flecha.gameObject.SetActive(false);
        activada_flecha=false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString(nombre_de_la_mision)=="DONE")
        {
            boton.interactable = false;
            //texto.text += '\u0336';
            texto.fontStyle = FontStyles.Strikethrough;
            gameObject.SetActive(false);
        }
        if(texto.color==Color.black) { activada_flecha = false; }
        
        
    }

    
    public void OnQuestClick()
    {
        if (activada_flecha == false)
        {
            apagar_todos();
            flecha.gameObject.SetActive(true);
            flecha.target = this.transform;

            texto.color = Color.red;
            activada_flecha = true;
        }
        else
        {
            flecha.gameObject.SetActive(false);
            flecha.target = null;

            texto.color = Color.black;
            activada_flecha = false;
        }
        
    }

    void apagar_todos()
    {
        for (int i = 0; i < otros.Length; i++)
        {
            otros[i].color= Color.black;
        }
    }
}