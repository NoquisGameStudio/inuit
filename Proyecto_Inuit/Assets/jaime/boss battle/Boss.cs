using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bola;
    public GameObject spawnPoint;

    public GameObject[] posiciones;
    public GameObject Sedna;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        //Ataquelineal();
        ataqueEstrella();
    }

    // Update is called once per frame
    void Update()
    {
        //cambioPosicion();
    }

    public void cambioPosicion()
    {
        for (int i = 0; i < posiciones.Length; i++)
        {
            int numalea = Random.Range(0, 10000);
            Debug.Log(numalea);
            if (numalea == 5)
            {            
                Sedna.transform.position = posiciones[i].transform.position;
                

            }
        }
    }
    public void Ataquelineal()
    {
        Quaternion rot=Quaternion.Euler(0f, 0f, 0f);

        if (player.transform.position.x < Sedna.transform.position.x)
        {
            rot = Quaternion.Euler(0f, 0f, 90f);
        }
        if (player.transform.position.x > Sedna.transform.position.x)
        {
            rot = Quaternion.Euler(0f, 0f, -90f);
        }

        GameObject b=Instantiate(bola, new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y ), rot);
        StartCoroutine(destroygameobject(b, 5));
        for (int i = 1; i < 4; i++)
        {

            GameObject one= Instantiate(bola, new Vector2(spawnPoint.transform.position.x,spawnPoint.transform.position.y+i),rot);
            GameObject two = Instantiate(bola, new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y - i), rot);

            StartCoroutine(destroygameobject(one, 10));
            StartCoroutine(destroygameobject(two, 10));
        }
    }

    public void ataqueEstrella()
    {
        float rot = 0f;
        for (int i = 0; i < 10; i++)
        {           
            GameObject b= Instantiate(bola, new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y ), gameObject.transform.rotation * Quaternion.Euler(0f, 0f, rot));
            rot +=40f;
            
            
            StartCoroutine(destroygameobject(b,10));

           
        }

    }

    IEnumerator destroygameobject(GameObject x, float secs)
    {
        yield return new WaitForSeconds(secs);
        Destroy(x);
    }
   
}
