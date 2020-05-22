using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

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
    public bool isTutorial = false;
    private int[] tSegmentList = new int[21];
    private int dayNum = 0;
    private int segIndex = 1;
    private int pWater, pFertilizer;
    private string currTime;
    private string[] timeOfDay = { "Morning", "Afternoon" };
    private Player player;

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

    public void ChangeText()
    {
        if (isTutorial)
        {
            tText.text = "Welcome to the tutorial!\nUse WASD to move Neirus. \nPress X to interact with the plant. \nUse space to read next text.";
            if (tSegment == 3)
            {
                tText.text = "Day: " + dayNum.ToString() + "\nTime: " + currTime.ToString() +
                    "\nWater: " + pWater + " Fertilizer: " + pFertilizer;
            }
        }
        else
        {
            if (dayNum <= 10)
            {
                tText.text = "Day: " + dayNum.ToString() + "\nTime: " + currTime.ToString() +
                    "\nWater: " + pWater + " Fertilizer: " + pFertilizer;
            }
            else
            {
                tText.text = "Time's Up!\nThank you for playing!\nDon't forget to fill out the survey.";
            }
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
