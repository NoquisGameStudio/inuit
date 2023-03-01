using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vida_player : MonoBehaviour
{
    public Image[] imagenes;
    public GameObject muerte;
    public int vida;
    int parpadeo = 0;
    // Start is called before the first frame update
    void Start()
    {
        vida = imagenes.Length;
        muerte.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (vida)
        {
            case 0:
                //muerte
                imagenes[0].sprite = null;
                imagenes[1].sprite = null;
                imagenes[2].sprite = null;
                imagenes[3].sprite = null;
                imagenes[4].sprite = null;
                muerte.SetActive(true);
                Time.timeScale = 0;


                break;
            case 1:
                if (parpadeo ==0)
                {

                    parpadeo = 1;
                }
                imagenes[1].sprite = null;
                imagenes[2].sprite = null;
                imagenes[3].sprite = null;
                imagenes[4].sprite = null;
                break;
            case 2:
                imagenes[2].sprite = null;
                imagenes[3].sprite = null;
                imagenes[4].sprite = null;
                break;
            case 3:
                imagenes[3].sprite = null;
                imagenes[4].sprite = null;
                break;
            case 4:
                imagenes[4].sprite = null;
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

            StartCoroutine(invulnerabilidad(GameObject.FindGameObjectWithTag("Player")));
        }
        
    }
}
