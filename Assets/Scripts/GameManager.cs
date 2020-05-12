using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<int> unusedStories = new List<int>() { 0, 1, 2 }; // Full list of unused story IDs
    private List<int> usedStories = new List<int>(); // List of currently assigned story IDs
    private int[] plantLocations = new int[6] { 0, 0, 0, 0, 0, 0 }; // 0: Vacant; 1: Occupied
    private Plant[] currentPlants = new Plant[6]; // Keeps track of all plants currently in the game
    //private GameObject firstPlant = null; // First plant in the game
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

    // Create a plant object before placing it in the game
    public void createPlant()
    {
        // Create and add plant to currentPlants[]
        Debug.Log("Creating Plant...");
        Plant plant;
        GameObject plantObject = GameObject.Find("Plant");
        plant = plantObject.GetComponent<Plant>();

        plant.setStory(assignStory());
        // Seeting Spawn Location Coordinates
        var (tempX, tempY) = assignOpenLocation();
        plant.setLocation(tempX, tempY);

        currentPlants[numberOfPlants] = plant;
        Debug.Log("currentPlants: " + currentPlants[numberOfPlants]);
        Debug.Log("Current # of plants: "+ numberOfPlants);
        numberOfPlants++;
        //Debug.Log("Unused Stories (after assign): " + unusedStories);
    }

    // Return a random story from the unusedStories list and transfer it to the usedStories when creating a plant
    private int assignStory()
    {
        //UnityEngine.Random rnd = new UnityEngine.Random();
        int storyIndex = UnityEngine.Random.Range(0, unusedStories.Count);
        Debug.Log("Assign Random story: " + storyIndex);
        int tempStory = unusedStories[storyIndex]; 
        // plant.setStory(tempStory);//***** GAME OBJECT ISN'T CONNECTED TO THE PLANT OBJECT
        usedStories.Add(tempStory);
        unusedStories.RemoveAt(storyIndex);
        return tempStory;
    }

    // Get an open location for the plant and spawn it in that location
    private (float, float) assignOpenLocation()
    {
        int locationIndex = -1;
        for (int i = 0; i < plantLocations.Length; i++)
        {
            if (plantLocations[i] == 0)
            {
                plantLocations[i] = 1;
                locationIndex = i;
                goto Coordinates;
            }
        }

    Coordinates:
        Debug.Log("Location index: " + locationIndex);
        switch (locationIndex)
        {
            case 0:
                return (5.81f, -1.38f);
            case 1:
                return (5.81f, -1.38f);
            case 2:
                return (5.81f, -1.38f);
            case 3:
                return (5.81f, -1.38f);
            case 4:
                return (5.81f, -1.38f);
            case 5:
                return (5.81f, -1.38f);
            default:
                return (0f, 0f);
        }
    }

}
