using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    private int numOfDay = 0;
    private string time = "Morning";
    public Sprite afternoonBG = null;
    public Sprite morningBG = null;
    private Sprite currSprite = null;
    public GameObject backgroundPic = null;

    void Start()
    {
        // assign the background object here.
        numOfDay = 1;
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
     * Need to do: fix the error descirbe below
     * Error: time value won't change to morning after chaning it to afternoon
     */
    public void ChangeTime()
    {
        if (time == "Afternoon" && numOfDay < 10)
        {
            time = "Morning";
            Debug.Log("Change to morning");
            ChangeBackground();
            UpdateDay();
        }
        if (time == "Morning" && numOfDay < 10)
        {
            time = "Afternoon";
            Debug.Log("Change to afternoon");
            ChangeBackground();
        }
    }

    private void UpdateDay()
    {
        numOfDay++;
    }

    /*
 * Need to do: fix the error descirbe below
 * Error: find a way to asign the background gameobject to door so that
 * the background can be changed after time change.
 */
    private void ChangeBackground()
    {
        SpriteRenderer rend = backgroundPic.GetComponent<SpriteRenderer>();
        currSprite = rend.GetComponent<Sprite>();
        if (time == "Morning")
        {
            rend.sprite = morningBG;
        }
        if (time == "Afternoon")
        {
            rend.sprite = afternoonBG;
        }
    }
}
