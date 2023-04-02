using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vida_player : MonoBehaviour
{
    public Image[] imagenes;
    //public GameObject muerte;
    public int vida;
    int parpadeo = 0;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        vida = imagenes.Length;
        // muerte.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        switch (vida)
        {
            case 0:
                //muerte
                imagenes[0].sprite = null;
                imagenes[0].gameObject.SetActive(false);
                imagenes[1].sprite = null;
                imagenes[1].gameObject.SetActive(false);
                imagenes[2].sprite = null;
                imagenes[2].gameObject.SetActive(false);
                imagenes[3].sprite = null;
                imagenes[3].gameObject.SetActive(false);
                imagenes[4].sprite = null;
                imagenes[4].gameObject.SetActive(false);
                //muerte.SetActive(true);
                //Time.timeScale = 0;
                muerte();
                
                break;
            case 1:
                if (parpadeo ==0)
                {

                    parpadeo = 1;
                }
                imagenes[1].sprite = null;
                imagenes[1].gameObject.SetActive(false);
                imagenes[2].sprite = null;
                imagenes[2].gameObject.SetActive(false);
                imagenes[3].sprite = null;
                imagenes[3].gameObject.SetActive(false);
                imagenes[4].sprite = null;
                imagenes[4].gameObject.SetActive(false);
                break;
            case 2:
                imagenes[2].sprite = null;
                imagenes[2].gameObject.SetActive(false);
                imagenes[3].sprite = null;
                imagenes[3].gameObject.SetActive(false);
                imagenes[4].sprite = null;
                imagenes[4].gameObject.SetActive(false);
                break;
            case 3:
                imagenes[3].sprite = null;
                imagenes[3].gameObject.SetActive(false);
                imagenes[4].sprite = null;
                imagenes[4].gameObject.SetActive(false);
                break;
            case 4:
                imagenes[4].sprite = null;
                imagenes[4].gameObject.SetActive(false);
                break;
            
        }
        if (parpadeo==1)
        {
            
            StartCoroutine(parpa());
        }
    }
    IEnumerator parpa()
    {
        parpadeo = 2; ;
        imagenes[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        imagenes[0].gameObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        StartCoroutine(parpa());
    }

    IEnumerator invulnerabilidad(GameObject i)
    {

        gameObject.layer = LayerMask.NameToLayer("inmune");

        i.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1f);
        yield return new WaitForSeconds(0.5f);
        i.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.7f);
        yield return new WaitForSeconds(0.5f);
        i.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1f);
        yield return new WaitForSeconds(0.5f);
        i.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.7f);
        yield return new WaitForSeconds(0.5f);
        i.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
        yield return new WaitForSeconds(0.5f);
        i.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.5f);

        gameObject.layer = LayerMask.NameToLayer("Default");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="stalactitas")
        {
            audio.Play();
            StartCoroutine(invulnerabilidad(GameObject.FindGameObjectWithTag("Player")));
        }
        
    }
    void muerte()
    {
        PlayerPrefs.SetFloat("DañoPlayer", PlayerPrefs.GetFloat("DañoPlayer") - 1);
        PlayerPrefs.SetString("agua", null);
        PlayerPrefs.SetString("helado", null);
        PlayerPrefs.SetString("manzana", null);
        PlayerPrefs.SetString("cueva", null);
        PlayerPrefs.SetString("caida", null);
        PlayerPrefs.SetString("pesca", null);
        PlayerPrefs.SetString("Ya_ha_peleado", "si");
        SceneManager.LoadScene("lobby_tiles");
    }
}
