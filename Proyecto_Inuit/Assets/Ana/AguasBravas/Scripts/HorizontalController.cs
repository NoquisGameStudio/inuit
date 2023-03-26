using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HorizontalController : MonoBehaviour
{
    public float speed;
    public float minPos = -5.0f;
    public float maxPos = 5.0f;
    private Vector2 position;
    
    public GameManager_AguasBravas gameManager;
    // Start is called before the first frame update
    void Start()
    {
        position.x = transform.position.x;
        position.y = transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        float aux = position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (!(aux > maxPos) && !(aux < minPos))
        {
            position.x = aux;
            transform.position = new Vector3(position.x, position.y, 0.0f);
        }
        else
        {
            transform.position = transform.position;
        }

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            gameManager.GameOver();
        }
        else if(other.gameObject.tag == "Score")
        {
            gameManager.IncreaseScore();
            Destroy(other.gameObject);
        }
    }
}
