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
    private int[] tSegmentList = new int[20];
    public Text tText;
    private int dayNum = 0;
    private int timeSegment;
    private int segIndex = 0;
    private string currTime;
    private string[] timeOfDay = new string[2] {"Morning", "Afternoon" };

    // need to fix the problem that when game reach to the end the text won't change to "Time's Up!"
    void Awake()
    {
        backgroundPic = GameObject.FindGameObjectWithTag("Background");
        tText = FindObjectOfType<Text>();
    }

    void Start()
    {
        dayNum = 1;
        for (int i = 0; i < tSegmentList.Length; i++)
        {
            tSegmentList[i] = i + 1;
        }
        timeSegment = tSegmentList[0];
        currTime = timeOfDay[0];
        ChangeBackground();
        ChangeText();
    }

    void Update()
    {
        ChangeText();
    }

    /*
     * This function will link with button to change background when player click on explore button.
     */
    public void ChangeTime()
    {
        if (dayNum <= 10)
        {
            if (currTime == timeOfDay[0])
            {
                currTime = timeOfDay[1];
                ChangeBackground();
                UpdateTimeSegment();
            }
            else
            {
                currTime = timeOfDay[0];
                ChangeBackground();
                UpdateTimeSegment();
                dayNum++;
                Debug.Log(dayNum);
            }
        }
    }

    private void ChangeBackground()
    {
        SpriteRenderer rend = backgroundPic.GetComponent<SpriteRenderer>();

        if (currTime == timeOfDay[0])
        {
            //rend.sprite = morningBG;
            rend.color = Color.grey;
        }
        if (currTime == timeOfDay[1])
        {
            //rend.sprite = afternoonBG;
            rend.color = Color.green;
        }
    }

    private void UpdateTimeSegment()
    {
        if (dayNum <= 10)
        {
            timeSegment = tSegmentList[segIndex + 1];
            segIndex++;
        }
    }

    public int GetTimeSegement()
    {
        return timeSegment;
    }

    private void ChangeText()
    {
        if (dayNum <= 10)
        {
            tText.text = "Day: " + dayNum.ToString() + "\nTime: " + currTime.ToString();
        }
        else
        {
            tText.text = "Time's Up!";
        }
    }
}
