﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/*
 * keep track with the game time and change the text showing game info
 * Game Manager, Plant, Nourishment System, and Tutorial have access to this script
 */
public class TimeSystem : MonoBehaviour
{
    [SerializeField]
    private Sprite afternoonBG = null;
    [SerializeField]
    private Sprite morningBG = null;
    [SerializeField]
    private GameObject bgPic = null;
    [SerializeField]
    private Text tText = null;

    [HideInInspector]
    public int tSegment;
    [HideInInspector]
    public bool isTutorial = false;

    private int dayNum = 0;
    private int segIndex = 1;
    private int pWater, pFertilizer;
    private int[] tSegmentList = new int[21];
    private string currTime;
    private string[] timeOfDay = { "Morning", "Afternoon" };
    private Player player;

    void Awake()
    {
        bgPic = GameObject.FindGameObjectWithTag("Background");
        player = FindObjectOfType<Player>();
    }

    void Start()
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

    void Update()
    {
        UpdateResourceAmount();
        ChangeText();
    }

    private void ChangeBackground()
    {
        SpriteRenderer rend = bgPic.GetComponent<SpriteRenderer>();
        if (currTime == timeOfDay[0])
        {
            rend.sprite = morningBG;
        }
        if (currTime == timeOfDay[1])
        {
            rend.sprite = afternoonBG;
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
        pWater = player.wAmount;
        pFertilizer = player.fAmount;
    }

    // update text for player to check game info
    private void ChangeText()
    {
        if (isTutorial)
        {
            tText.text = "Welcome to the tutorial!\nUse WASD to move Neirus. \nPress X to interact with the plant. \nUse space to read next text.";
        }
        else
        {
            if (dayNum <= 10)
            {
                tText.text = "Day: " + dayNum.ToString() + "\nTime: " + currTime.ToString() +
                    "\nWater: " + pWater + " Fertilizer: " + pFertilizer;
            }
        }

        if (tSegment == 21)
        {
            tText.text = "It's time. \nYou need go back to your team. \nPress X to leave the greenhouse.";
        }
    }

    // link with button to change time
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
