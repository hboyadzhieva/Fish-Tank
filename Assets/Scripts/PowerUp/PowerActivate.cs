using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PowerActivate : MonoBehaviour
{
    [SerializeField]
    private GameObject powerUI;
    [SerializeField]
    private GameObject powerIcon;
    private TimerBar timerBar;

    public virtual void activatePower()
    {
        Debug.Log("POWER ACTIVATED");
        powerUI.SetActive(true);
        timerBar = powerUI.GetComponentInChildren<TimerBar>();
        powerIcon.GetComponent<Image>().sprite = powerSprite();
        timerBar.timesUp += deactivatePower;
        
    }

    public virtual void deactivatePower()
    {
        powerUI.SetActive(false);
        Debug.Log("POWER DEACTIVATED");
        timerBar.timesUp -= deactivatePower;
    }

    private Sprite powerSprite()
    {
        return GetComponentInParent<SpriteRenderer>().sprite;
    }

}
