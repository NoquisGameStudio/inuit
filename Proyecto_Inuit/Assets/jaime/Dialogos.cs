using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]


public class Dialogos : MonoBehaviour
{
    public string nombre;

    [TextArea(3, 10)]
    public string[] frasesESP;
    public string[] frasesENG;

    
}
