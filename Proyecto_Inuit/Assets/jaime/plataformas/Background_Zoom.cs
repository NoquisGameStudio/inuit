using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Zoom : MonoBehaviour
{
    public Camera mainCamera;

    private float initialCameraSize;
    private float initialSpriteScale;
    private float targetSpriteScale;

    void Start()
    {
        // Guardar los valores iniciales
        initialCameraSize = mainCamera.orthographicSize;
        initialSpriteScale = transform.localScale.x;
        targetSpriteScale = initialSpriteScale;
    }

    void Update()
    {
        float targetScale = initialSpriteScale * (mainCamera.orthographicSize / initialCameraSize);

        targetSpriteScale = Mathf.Lerp(targetSpriteScale, targetScale, Time.deltaTime);

        transform.localScale = new Vector3(targetSpriteScale, targetSpriteScale, transform.localScale.z);
    }
}
