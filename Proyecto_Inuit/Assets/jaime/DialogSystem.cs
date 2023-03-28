using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogSystem : MonoBehaviour
{
    public TMP_Text nombreTexto;
    public TMP_Text dialogueTexto;

    //public Animator animator;

    private Queue<string> frases;

    // Start is called before the first frame update
    void Start()
    {
        nombreTexto.gameObject.SetActive(false);
        dialogueTexto.gameObject.SetActive(false);
        frases = new Queue<string>();
    }

    public void StartDialogue(Dialogos D)
    {
        //animator.SetBool("IsOpen", true);
        nombreTexto.gameObject.SetActive(true);
        dialogueTexto.gameObject.SetActive(true);
        Debug.Log("conversacion con " + D.nombre);
        nombreTexto.text = D.nombre;

        frases.Clear();

        foreach (string frase in D.frases)
        {
            frases.Enqueue(frase);
        }

        DisplayNextFrase();
    }

    public void DisplayNextFrase()
    {
        if (frases.Count == 0)
        {
            EndDialogue();
            return;
        }

        string frase = frases.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Escitura(frase));
    }

    public void OnEspacio(InputValue input)
    {
        DisplayNextFrase();
    }

    IEnumerator Escitura(string frase)
    {
        dialogueTexto.text = "";
        foreach (char letter in frase.ToCharArray())
        {
            dialogueTexto.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        Debug.Log("final");
        nombreTexto.gameObject.SetActive(false);
        dialogueTexto.gameObject.SetActive(false);
        // animator.SetBool("IsOpen", false);
    }
}
