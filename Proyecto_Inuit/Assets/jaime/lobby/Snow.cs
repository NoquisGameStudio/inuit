using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public GameObject snowflakePrefab; // Prefab de la nieve
    public float snowflakeSpawnRate = 0.0001f; // Tasa de generación de nieve
    public float snowflakeSpeed = 0.1f; // Velocidad de la nieve

    private float snowflakeSpawnTimer = 0.0f; // Temporizador de generación de nieve
    private Transform m_Camera;

    private void Start()
    {
        m_Camera = Camera.main.transform;
    }
    void Update()
    {
        // Incrementar el temporizador de generación de nieve
        snowflakeSpawnTimer += Time.deltaTime;

        // Generar nieve aleatoriamente en la escena
        if (snowflakeSpawnTimer >= snowflakeSpawnRate)
        {
            // Resetear el temporizador
            snowflakeSpawnTimer = 0.0f;

            // Generar una copia del prefab de nieve
            GameObject snowflake = Instantiate(snowflakePrefab);

            // Asignar una posición aleatoria en la parte superior de la pantalla
            float x = Random.Range(m_Camera.position.x - 10.0f, m_Camera.position.x + 10.0f);
            float y = m_Camera.position.y + 6.0f;
            snowflake.transform.position = new Vector3(x, y, 0.0f);

            // Asignar una velocidad aleatoria a la nieve
            float speed = Random.Range(snowflakeSpeed / 2, snowflakeSpeed);
            snowflake.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, -speed);

            float rangotiempo = Random.Range(3.0f, 6.0f);

            Destroy(snowflake, rangotiempo);
        }
    }
}
