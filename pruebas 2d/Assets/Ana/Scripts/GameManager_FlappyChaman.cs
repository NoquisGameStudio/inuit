using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_FlappyChaman : MonoBehaviour
{
    private int score;

    public void GameOver()
    {
        Debug.Log("Game over");
    }
    
    public void IncreaseScore()
    {
        score++;
    }
}