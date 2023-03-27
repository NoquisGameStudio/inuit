using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barca : MonoBehaviour
{
   public SpriteRenderer s;
   
   private void Update()
   {
      if (transform.position.x < 0.0f)
      {
         s.flipX = true;
      }
      else
      {
         s.flipX = false;
      }
   }
}
