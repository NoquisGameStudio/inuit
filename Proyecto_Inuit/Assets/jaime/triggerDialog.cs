using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class triggerDialog : MonoBehaviour
{
    public Dialogos Dialogo;
    public GameObject bocata;
     bool dentro;
    public DialogSystem d;
    void Start()
    {
        bocata.SetActive(false);
        dentro=false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            dentro = true;
            bocata.SetActive(true);
            d = FindObjectOfType<DialogSystem>();

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            dentro = false;
            bocata.SetActive(false);

        }
    }
    public void OnInteract(InputValue input)
    {

        if (dentro)
        {
            Debug.Log("eeeeee");
            d.StartDialogue(Dialogo);
        }
    }

}
