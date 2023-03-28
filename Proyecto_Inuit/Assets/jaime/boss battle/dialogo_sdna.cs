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
    void Start()
    {
        barra_vida.SetActive(false);
        corazones.SetActive(false);
        sedna.SetActive(false);
        bocata.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void OnInteract(InputValue input)
    {

        if (dentro)
        {
            barra_vida.SetActive(true);
            corazones.SetActive(true);
            sedna.SetActive(true);
            bocata.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
