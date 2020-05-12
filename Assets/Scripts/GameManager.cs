﻿using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<int> unusedStories = new List<int>() { 0, 1, 2 }; // Full list of unused story IDs
    private List<int> usedStories = new List<int>(); // List of currently assigned story IDs
    private int[] plantLocations = new int[6] { 0, 0, 0, 0, 0, 0 }; // 0: Vacant; 1: Occupied
    private GameObject[] currentPlants = new GameObject[6]; // Keeps track of all plants currently in the game
    private GameObject firstPlant = null; // First plant in the game
    private int numberOfPlants = 0;
    private TimeSystem tSystem;
    private PlayerActions pActions;

    void Awake()
    {
        GameObject temDoor = Resources.Load<GameObject>("Prefabs/Door");
        GameObject door = Instantiate(temDoor);
        door.transform.position = new Vector3(-.23f, -7.99f, 0f);
        //CreateFirstPlant();

        // get access to Time System and Player Action script
        tSystem = door.GetComponent<TimeSystem>();
        pActions = door.GetComponent<PlayerActions>();
    }

    /*****Create plant should be called when the player reaches a certain time segment and goes outside*****/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            createPlant();
            numberOfPlants++;
        }

        // Disable the door when game's over
        if (tSystem.tSegment == 21)
        {
            pActions.SetMenu(false);
        }
    }

    /**
     * Need to find a way to create the flowchart object and add it to the plant create in this function
     **/
    private void CreateFirstPlant()
    {
        /*GameObject p = Instantiate(firstPlant);
        float x = 5.81f;
        float y = -1.38f;
        p.transform.position = new Vector3(x, y, -5f);
        numberOfPlants++;
        assignStory(p);*/

    }

    // Create a plant object before placing it in the game
    public void createPlant()
    {
        // Create and add plant to currentPlants[]
        firstPlant = Resources.Load<GameObject>("Prefabs/Plant");
        GameObject p = Instantiate(firstPlant);
        Debug.Log("Creating Plant...");
        currentPlants[numberOfPlants] = p;
        assignStory(p);
        assignOpenLocation(p);

        Debug.Log("currentPlants: " + currentPlants[numberOfPlants]);
        numberOfPlants++;
        //Debug.Log("Unused Stories (after assign): " + unusedStories);
    }

    // Return a random story from the unusedStories list and transfer it to the usedStories when creating a plant
    private void assignStory(GameObject plant)
    {
        //Debug.Log("Unused Stories: " + unusedStories);
        UnityEngine.Random rnd = new UnityEngine.Random();
        int storyIndex = UnityEngine.Random.Range(0, unusedStories.Count);
        int tempStory = unusedStories[storyIndex];
        // plant.setStory(tempStory);//***** GAME OBJECT ISN'T CONNECTED TO THE PLANT OBJECT
        usedStories.Add(tempStory);
        unusedStories.RemoveAt(storyIndex);

    }

    // Get an open location for the plant and spawn it in that location
    private int assignOpenLocation(GameObject plant)
    {
        float x = 5.81f;
        float y = -1.38f;
        plant.transform.position = new Vector3(x, y, -5f);

        return 0;
    }

    private void addToUsedStories()
    {

    }
}
