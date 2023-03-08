using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Scene_Change : MonoBehaviour
{
    public string Scene_to_load;

    public bool dentro=false;

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
        if (collision.gameObject.tag=="Player")
        {
            dentro = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dentro = false;
        }
    }

    public void OnInteract(InputValue input)
    {
        Debug.Log("eeee");
        if (dentro)
        {
            SceneManager.LoadScene(Scene_to_load);
        }
    }
}
