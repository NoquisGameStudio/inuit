using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisparoPlayer : MonoBehaviour
{
    movement mov;

    public GameObject proyectil;
    public GameObject spawnPoint;

    Vector2 direccion_mov;

    public float velocidad_proyectil;
    

    // Start is called before the first frame update
    void Start()
    {
        mov = gameObject.GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        direccion_mov = mov.mov;
    }

    
    public void OnDisparo(InputValue input)
    {

        if (PlayerPrefs.GetString("puede_disparar")=="True")
        {

            GameObject p = Instantiate(proyectil, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        

            StartCoroutine(destroygameobject(p, 5));
        }


    }

    IEnumerator destroygameobject(GameObject x, float secs)
    {
        yield return new WaitForSeconds(secs);
        Destroy(x);
    }
}
