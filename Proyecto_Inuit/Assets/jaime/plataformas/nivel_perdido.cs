using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nivel_perdido : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("Da�oPlayer", PlayerPrefs.GetFloat("Da�oPlayer") - 1);
        SceneManager.LoadScene("lobby_tiles");
    }
}
