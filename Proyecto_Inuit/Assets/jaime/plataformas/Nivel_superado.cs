using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel_superado : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetFloat("Da�oPlayer", PlayerPrefs.GetFloat("Da�oPlayer") + 5);
        SceneManager.LoadScene("lobby_tiles");
    }

}
