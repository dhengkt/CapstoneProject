﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSystem : MonoBehaviour
{
    [SerializeField]
    private Sprite afternoonBG = null;
    [SerializeField]
    private Sprite morningBG = null;
    [SerializeField]
    private GameObject bgPicture = null;
    [SerializeField]
    private Text tText;

    public int tSegment;
    private int[] tSegmentList = new int[21];
    private int dayNum = 0;
    private int segIndex = 1;
    private string currTime;
    private string[] timeOfDay = { "Morning", "Afternoon" };
    private Player player;
    private int water, fertilizer;

    private void Awake()
    {
        bgPicture = GameObject.FindGameObjectWithTag("Background");
        tText = FindObjectOfType<Text>();
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        dayNum = 1;
        for (int i = 0; i < tSegmentList.Length; i++)
        {
            tSegmentList[i] = i + 1;
        }
        tSegment = tSegmentList[0];
        currTime = timeOfDay[0];
        ChangeBackground();
        ChangeText();
    }

    private void Update()
    {
        UpdateResourceAmount();
        ChangeText();
    }

    private void ChangeBackground()
    {
        SpriteRenderer rend = bgPicture.GetComponent<SpriteRenderer>();

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
        if (dayNum <= 11)
        {
            tSegment = tSegmentList[segIndex];
            segIndex++;
        }
    }

    private void UpdateResourceAmount()
    {
        water = player.wAmount;
        fertilizer = player.fAmount;
    }

    private void ChangeText()
    {
        if (dayNum <= 10)
        {
            tText.text = "Day: " + dayNum.ToString() + "\nTime: " + currTime.ToString() + 
                "\nWater: " + water + " Fertilizer: " + fertilizer;
        }
        else
        {
            tText.text = "Time's Up!";
        }
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
                dayNum++;
                currTime = timeOfDay[0];
                ChangeBackground();
                UpdateTimeSegment();
            }
        }
    }

}
