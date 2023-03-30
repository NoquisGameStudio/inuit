using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inicio_trigger : MonoBehaviour
{
    public Dialogos Dialogo;
    public GameObject bocata;
   
    public DialogSystem d;

    public Animator anim_alcalde;

    public GameObject botones;
    public GameObject wk;
    public GameObject ak;
    public GameObject sk;
    public GameObject dk;

    void Start()
    {
        bocata.SetActive(false);
        
        botones.SetActive(false);
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            
            d = FindObjectOfType<DialogSystem>();
            d.StartDialogue(Dialogo);
            gameObject.GetComponent<Collider2D>().enabled = false;

        }
    }
    private void Update()
    {
        if (d.se_acabo==true)
        {
            anim_alcalde.SetBool("correr", true);
            botones.SetActive(true);
        }

        if (wk.activeInHierarchy==false && ak.activeInHierarchy == false && sk.activeInHierarchy == false && dk.activeInHierarchy == false )
        {
            botones.SetActive(false);
        }
    }

    public void OnW(InputValue input)
    {
        if (d.se_acabo == true)
        {
            wk.SetActive(false);

        }
    }
    public void OnA(InputValue input)
    {
        if (d.se_acabo == true)
        {

            ak.SetActive(false);
        }
    }
    public void OnS(InputValue input)
    {
        if (d.se_acabo == true)
        {

            sk.SetActive(false);
        }
    }
    public void OnD(InputValue input)
    {
        if (d.se_acabo == true)
        {
            dk.SetActive(false);

        }
    }

}
