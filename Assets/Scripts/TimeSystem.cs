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
    private int[] timeSegmentList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    public Text timeText;
    private int numOfDay = 0;
    private int timeSegment;
    private int segmentIndex = 0;
    private string timeOfDay = "Morning";

    /*
     * TODO: find a way to let Game Manager has the access to the variables here. 
     */
    void Start()
    {
        backgroundPic = GameObject.FindGameObjectWithTag("Background");
        numOfDay = 1;
        timeText = FindObjectOfType<Text>();
        timeSegment = timeSegmentList[0];
    }

    void Update()
    {
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
            UpdateTimeSegment();
            Debug.Log(timeSegment);
        }
        else
        {
            ChangeBackground();
            timeOfDay = "Morning";
            UpdateTimeSegment();
            numOfDay++;
            Debug.Log(timeSegment);
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

    private void UpdateTimeSegment()
    { 
        timeSegment = timeSegmentList[segmentIndex+1];
        segmentIndex++;
    }

    public int GetTimeSegement()
    {
        return timeSegment;
    }
}
