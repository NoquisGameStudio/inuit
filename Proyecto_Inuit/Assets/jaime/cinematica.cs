using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cinematica : MonoBehaviour
{
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (g.transform.position.y< 14.01082)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("menu_principal");
        }
    }
}
