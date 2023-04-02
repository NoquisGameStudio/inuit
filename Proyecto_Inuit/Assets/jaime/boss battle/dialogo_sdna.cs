using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class dialogo_sdna : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject barra_vida;
    public GameObject corazones;
    public GameObject sedna;
    public bool dentro = false;
    public GameObject bocata;

    public DialogSystem d;
    void Start()
    {
        PlayerPrefs.SetString("puede_disparar", "f");
        barra_vida.SetActive(false);
        corazones.SetActive(false);
        sedna.SetActive(false);
        bocata.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        d = FindObjectOfType<DialogSystem>();
        if (d.se_acabo==true)
        {
            PlayerPrefs.SetString("puede_disparar", "True");
            barra_vida.SetActive(true);
            corazones.SetActive(true);
            sedna.SetActive(true);
            bocata.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bocata.SetActive(true);
            dentro = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bocata.SetActive(false);
            dentro = false;
        }
    }

    

}
