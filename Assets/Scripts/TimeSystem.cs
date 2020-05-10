using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] Sprite afternoonBG = null;
    [SerializeField] Sprite morningBG = null;
    public GameObject backgroundPic = null;
    public List<int> timeSegementList = new List<int>(); // will be used by game manager and plant object to keep track of time
    public Text timeText;
    private int numOfDay = 0;
    private int timeSegement;
    private string timeOfDay = "Morning";

    /*
     * TODO: find a way to let Game Manager has the access to the variables here. 
     */
    void Start()
    {
        backgroundPic = GameObject.FindGameObjectWithTag("Background");
        numOfDay = 1;
        timeText = FindObjectOfType<Text>();
        //timeSegement = 1;
        //timeSegementList.Add(timeSegement);
    }

    void Update()
    {
        Debug.Log(numOfDay);
        timeText.text = "Day: " + numOfDay.ToString() + "\nTime: " + timeOfDay.ToString();
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
            //rend.sprite = morningBG;
            rend.color = new Color(219f, 157f, 61f, 255f);
        }
        if (timeOfDay == "Afternoon")
        {
            //rend.sprite = afternoonBG;
            rend.color = Color.green;
        }
    }
}
