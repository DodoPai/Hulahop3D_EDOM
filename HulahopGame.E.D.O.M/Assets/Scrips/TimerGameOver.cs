using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGameOver : MonoBehaviour
{
    public static int countDownStartValue = 20;
    public Text Printtimer;

    private void Start()
    {
        countDownTimer();

    }
    private void Update()
    {
        countDownStartValue = Mathf.Clamp(countDownStartValue,0, 20);
        Printtimer.text = "Time: " + countDownStartValue;
        if (TrueBall.score >= 300)
        {
            countDownStartValue = Mathf.Clamp(countDownStartValue, 0, 10);
        }
    }
    void countDownTimer()
    {
        if(countDownStartValue > 0)
        {
            
            
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);  //1sn sonra çek bu metodu.
           
        }
        
    }
}
