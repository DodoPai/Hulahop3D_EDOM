using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        TimerGameOver.countDownStartValue = 20;
        






    }

    void Update()
    {
        

        if (TimerGameOver.countDownStartValue ==0)
        {
            gameOver = true;
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        
        
    }
    
}
