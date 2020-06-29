﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PowerActivate : MonoBehaviour
{
    private GameObject powerUI;
    private GameObject powerIcon;
    private TimerBar timerBar;

    public GameObject PowerUI { get => powerUI; set => powerUI = value; }
    public GameObject PowerIcon { get => powerIcon; set => powerIcon = value; }
    public TimerBar TimerBar { get => timerBar; set => timerBar = value; }

    public virtual void activatePower()
    {
        Debug.Log("POWER ACTIVATED");
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        PowerUI = Helper.FindObject(canvas.gameObject, "PowerUI");
        GameObject timer = Helper.FindObject(PowerUI, "Timer");
        PowerIcon = Helper.FindObject(timer, "Icon");
        PowerUI.SetActive(true);
        TimerBar = PowerUI.GetComponentInChildren<TimerBar>();
        PowerIcon.GetComponent<Image>().sprite = powerSprite();
        TimerBar.timesUp += deactivatePower;
        
    }

    public virtual void deactivatePower()
    {
        PowerUI.SetActive(false);
        Debug.Log("POWER DEACTIVATED");
        TimerBar.timesUp -= deactivatePower;
    }

    private Sprite powerSprite()
    {
        return GetComponentInParent<SpriteRenderer>().sprite;
    }

}
