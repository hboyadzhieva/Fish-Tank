using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Gradient gradient;
    [SerializeField]
    private Image fill;
    
    public float maxTime = 5f;
    float timeLeft;
    public event Action timesUp;

/*    public void Start()
    {
        timeLeft = maxTime;
        slider.maxValue = timeLeft/maxTime;
        fill.color = gradient.Evaluate(timeLeft / maxTime);
    }*/

    private void OnEnable()
    {
        timeLeft = maxTime;
        slider.maxValue = timeLeft / maxTime;
        fill.color = gradient.Evaluate(timeLeft / maxTime);
    }

    private void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            slider.value = timeLeft / maxTime;
            fill.color = gradient.Evaluate(timeLeft / maxTime);
        }
        else
        {
            timesUp?.Invoke();
        }
    }



}
