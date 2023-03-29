using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Zoom : MonoBehaviour
{
    public Camera mainCamera; // Referencia a la cámara principal

    private float initialCameraSize; // Tamaño de la cámara en el inicio del juego
    private float initialSpriteScale; // Escala del sprite en el inicio del juego
    private float targetSpriteScale; // Escala objetivo del sprite

    void Start()
    {
        // Guardar los valores iniciales
        initialCameraSize = mainCamera.orthographicSize;
        initialSpriteScale = transform.localScale.x;
        targetSpriteScale = initialSpriteScale;
    }

    void Update()
    {
        // Calcular la escala objetivo del sprite
        float targetScale = initialSpriteScale * (mainCamera.orthographicSize / initialCameraSize);

        // Interpolar entre la escala actual y la escala objetivo
        targetSpriteScale = Mathf.Lerp(targetSpriteScale, targetScale, Time.deltaTime);

        // Aplicar la escala objetivo al sprite
        transform.localScale = new Vector3(targetSpriteScale, targetSpriteScale, transform.localScale.z);
    }
}
