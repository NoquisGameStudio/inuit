using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delante_detras_sprites : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

}
