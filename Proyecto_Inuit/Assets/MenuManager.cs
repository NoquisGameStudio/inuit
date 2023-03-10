using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator anim_libro;
    public GameObject botones_iniciales;
    public GameObject botones_settings;

    // Start is called before the first frame update
    void Start()
    {
        botones_settings.SetActive(false);
        StartCoroutine(bot(botones_iniciales));
        anim_libro.Play("abrir");

    }

    IEnumerator bot(GameObject boton)
    {
        boton.SetActive(false);
        yield return new WaitForSeconds(0.75f);
        boton.SetActive(true);
    }

    IEnumerator GameStart()
    {
        botones_iniciales.SetActive(false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("lobby_tiles");
        
    }

    public void PLAY()
    {
        StartCoroutine(GameStart());
        anim_libro.Play("cerrar");

    }

    IEnumerator GameSettings(GameObject desaparece, GameObject aparece)
    {
        desaparece.SetActive(false);
        yield return new WaitForSeconds(1);
        aparece.SetActive(true);

    }
    public void SETTINGS()
    {
        StartCoroutine(GameSettings(botones_iniciales,botones_settings));
        anim_libro.Play("pag");

    }

    public void EXIT_SETTINGS()
    {
        StartCoroutine(GameSettings(botones_settings,botones_iniciales));
        anim_libro.Play("pag_reves");

    }

    IEnumerator GameClose()
    {
        botones_iniciales.SetActive(false);
        yield return new WaitForSeconds(1);
        Application.Quit();

    }

    public void EXIT()
    {
        StartCoroutine(GameClose());
        anim_libro.Play("cerrar");

    }
}
