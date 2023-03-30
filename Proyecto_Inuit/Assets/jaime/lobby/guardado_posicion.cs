using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardado_posicion : MonoBehaviour
{
    // Start is called before the first frame update

    //public bool pr;//falsa por default

    private void Awake()
    {
    }
    void Start()
    {

        if (PlayerPrefs.GetFloat("PlayerX")!=0 && PlayerPrefs.GetFloat("PlayerY")!=0 && PlayerPrefs.GetFloat("PlayerZ")!=0)
        {

        }
        else
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));

        }

        

    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
    }
}
