using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaSedna : MonoBehaviour
{

    public float vida_max;
    public float vida_actual;
    public float da�o;

    public Image img_vida;
    public GameObject txt_win;
    // Start is called before the first frame update
    void Start()
    {
        vida_actual = vida_max;
        txt_win.SetActive(false);
        PlayerPrefs.SetFloat("Da�oPlayer", PlayerPrefs.GetFloat("Da�oPlayer") + da�o);
        da�o = PlayerPrefs.GetFloat("Da�oPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        img_vida.fillAmount = vida_actual / vida_max;

        if (vida_actual<=0)
        {
            txt_win.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Proyectil")
        {
            vida_actual = vida_actual - PlayerPrefs.GetFloat("Da�oPlayer");

        }
    }
}
