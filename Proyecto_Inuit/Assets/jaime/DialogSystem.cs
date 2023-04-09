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

    public Animator animator;

    private Queue<string> frases;
    public bool se_acabo;

    // Start is called before the first frame update
    void Start()
    {
        se_acabo= false;
        //nombreTexto.gameObject.SetActive(false);
        //dialogueTexto.gameObject.SetActive(false);
        frases = new Queue<string>();
    }

    public void StartDialogue(Dialogos D)
    {
        se_acabo= false;
        animator.SetBool("arriba", true);
        //nombreTexto.gameObject.SetActive(true);
       // dialogueTexto.gameObject.SetActive(true);
        Debug.Log("conversacion con " + D.nombre);
        nombreTexto.text = D.nombre;
        
        frases.Clear();

        int idioma = PlayerPrefs.GetInt("Idioma", 0);
        if (idioma == 0)
        {
            foreach (string frase in D.frasesENG)
            {
                frases.Enqueue(frase);
            }
        }
        else
        {
            foreach (string frase in D.frasesESP)
            {
                frases.Enqueue(frase);
            }
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
        Debug.Log("add ");
        //DisplayNextFrase();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextFrase();
        }
    }

    IEnumerator Escitura(string frase)
    {
        dialogueTexto.text = "";
        foreach (char letter in frase.ToCharArray())
        {
            dialogueTexto.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }
    public void EndDialogue()
    {
        Debug.Log("final");
        //nombreTexto.gameObject.SetActive(false);
        //dialogueTexto.gameObject.SetActive(false);
        animator.SetBool("arriba", false);
        se_acabo = true;
    }
}
