using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MANAGER_LOBBY : MonoBehaviour
{
    public TMP_Text poder;
    
    public string[] Nombres_misiones;
    public GameObject[] GameObjects_misiones;
    string[] misiones_activas=new string[3];

  

    


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        poder.text = "Power: " + PlayerPrefs.GetFloat("DañoPlayer");
        
    }
}
