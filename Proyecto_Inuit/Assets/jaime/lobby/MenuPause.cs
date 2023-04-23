using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    public Animator anim_libro;
    public GameObject botones_iniciales;
    public GameObject botones_settings;
    public GameObject botones_buy;

    public Slider volumen;
    public AudioMixer mixer;

    AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        //PlayerPrefs.DeleteAll();
        botones_settings.SetActive(false);
        botones_buy.SetActive(false);
        StartCoroutine(bot(botones_iniciales));
        anim_libro.Play("abrir");

        volumen.onValueChanged.AddListener(delegate { ModificarVolumen(); });
    }

    private void ModificarVolumen()
    {
        mixer.SetFloat("Sounds", Mathf.Log10(volumen.value) * 20);
    }

    IEnumerator bot(GameObject boton)
    {
        boton.SetActive(false);
        audio.Play();
        yield return new WaitForSeconds(0.75f);
        boton.SetActive(true);
    }

    IEnumerator GameStart()
    {
        botones_iniciales.SetActive(false);
        audio.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("intro");
        
    }
    IEnumerator GameLoad()
    {
        PlayerPrefs.SetInt("Partida_nueva", 0);
        PlayerPrefs.Save();
        botones_iniciales.SetActive(false);
        audio.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("lobby_tiles");

    }

    public void PLAY()
    {
        StartCoroutine(GameStart());
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("Partida_guardada", 1);
        anim_libro.Play("cerrar");

    }

    public void LOAD_GAME()
    {
        StartCoroutine(GameLoad());
        anim_libro.Play("cerrar");

    }

    public Button load;
    void Update()
    {
        if (PlayerPrefs.GetFloat("Partida_guardada") == 0)
        {
            load.interactable = false;
        }
        else
        {
            load.interactable = true;
        }
    }

    IEnumerator GameSettings(GameObject desaparece, GameObject aparece)
    {
        desaparece.SetActive(false);
        audio.Play();
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
    public void BUY()
    {
        StartCoroutine(GameSettings(botones_iniciales, botones_buy));
        anim_libro.Play("pag");

    }
    public void EXIT_BUY()
    {
        StartCoroutine(GameSettings(botones_buy,botones_iniciales));
        anim_libro.Play("pag_reves");

    }

    IEnumerator GameClose()
    {
        botones_iniciales.SetActive(false);
        audio.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("menu_principal");

    }

    public void EXIT()
    {
        StartCoroutine(GameClose());
        anim_libro.Play("cerrar");

    }
}
