using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    private int numOfDay = 0;
    private int timeSegement;
    private string timeOfDay = "Morning";
    [SerializeField] Sprite afternoonBG = null;
    [SerializeField] Sprite morningBG = null;
    public GameObject backgroundPic = null;
    public List<int> timeSegementList = new List<int>(); // will be used by game manager and plant object to keep track of time

    void Start()
    {
        // assign the background object here.
        backgroundPic = GameObject.FindGameObjectWithTag("Background");
        numOfDay = 1;
        timeSegement = 1;
        timeSegementList.Add(timeSegement);
    }

    void Update()
    {
        Debug.Log(numOfDay);
        if (numOfDay == 10)
        {
            Debug.Log("Game Over!");
        }
    }

    /*
     * This function will link with button to change background when player click on explore button.
     */
    public void ChangeTime()
    {
        if (numOfDay < 10 && timeOfDay == "Morning")
        {
            ChangeBackground();
            timeOfDay = "Afternoon";
        }
        else
        {
            ChangeBackground();
            timeOfDay = "Morning";
            numOfDay++;
        }
    }

    private void ChangeBackground()
    {
        SpriteRenderer rend = backgroundPic.GetComponent<SpriteRenderer>();
        if (timeOfDay == "Morning")
        {
            rend.sprite = morningBG;
        }
        if (timeOfDay == "Afternoon")
        {
            rend.sprite = afternoonBG;
        }
    }
}
