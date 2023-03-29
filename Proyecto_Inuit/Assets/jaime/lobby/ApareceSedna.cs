using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApareceSedna : MonoBehaviour
{
    public GameObject lago;
    public GameObject tp;

    public FlechaMisiones flecha;


    // Start is called before the first frame update
    void Start()
    {
        lago.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("agua")=="DONE"&&
        PlayerPrefs.GetString("helado") == "DONE" &&
        PlayerPrefs.GetString("manzana") == "DONE" &&
        PlayerPrefs.GetString("cueva") == "DONE" &&
        PlayerPrefs.GetString("caida") == "DONE" &&
        PlayerPrefs.GetString("pesca") == "DONE" )
        {
            lago.SetActive(true);
            flecha.gameObject.SetActive(true);
            flecha.target = tp.transform;
        }
        if(PlayerPrefs.GetString("Ya_ha_peleado") == "si")
        {
            lago.SetActive(true);
        }
    }
}
