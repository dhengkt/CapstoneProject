using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Keep track plant's properties like number, story flowcharts and location; also keep track with the creation of plant
 * Link with Time System and ActionMenu scripts to know game time and whether Door is function or not
 */
public class GameManager : MonoBehaviour
{   
    private List<int> unusedStories = new List<int>() { 0, 1, 2, 3, 4};
    private List<int> usedStories = new List<int>();

    // 0: Vacant; 1: Occupied
    private int[] plantLocations = new int[6] { 0, 0, 0, 0, 0, 0 };

    // Keeps track of all plants currently in the game
    private Plant[] currentPlants = new Plant[6];

    private int numberOfPlants = 0;
    private TimeSystem tSystem;
    private ActionsMenu dOptions;

    void Awake()
    {
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        door.transform.position = new Vector3(-.23f, -7.99f, 0f);

        // get access to Time System and Player Action script
        tSystem = door.GetComponent<TimeSystem>();
        dOptions = door.GetComponent<ActionsMenu>();
    }

    // Create plants at set time segments
    void Update()
    {
        if (tSystem.tSegment == 1 && numberOfPlants != 1)
        {
            CreatePlant();
        }
        if (tSystem.tSegment == 4 && numberOfPlants != 2)
        {
            CreatePlant();
        }
        if (tSystem.tSegment == 8 && numberOfPlants != 3)
        {
            CreatePlant();
        }

        if (tSystem.tSegment == 21 && Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void CreatePlant()
    {
        numberOfPlants++;
        // Create and add plant to currentPlants[]
        Debug.Log("Creating Plant...");
        Plant plant;
        GameObject p = Resources.Load<GameObject>("Prefabs/Plant");
        GameObject plantObject = Instantiate(p);
        plant = plantObject.GetComponent<Plant>();
        NourishmentSystem nSystem = plant.GetComponent<NourishmentSystem>();
        nSystem.gameObject.SetActive(true);
        nSystem.plantNumber = numberOfPlants;

        plant.SetStory(AssignStory());
        // Seeting Spawn Location Coordinates
        var (tempX, tempY) = AssignOpenLocation();
        plant.SetLocation(tempX, tempY);

        currentPlants[numberOfPlants] = plant;
        Debug.Log("currentPlants: " + currentPlants[numberOfPlants]);
        Debug.Log("Current # of plants: "+ numberOfPlants);
    }

    // Return a random story from the unusedStories list and transfer it to the usedStories when creating a plant (no story repeats)
    private int AssignStory()
    {
        int storyIndex = UnityEngine.Random.Range(0, unusedStories.Count);
        Debug.Log("Assign Random story: " + storyIndex);
        int tempStory = unusedStories[storyIndex]; 
        usedStories.Add(tempStory);
        unusedStories.RemoveAt(storyIndex);
        return tempStory;
    }

    // Returns coordinates of an open location for the plant and spawn it in that location
    private (float, float) AssignOpenLocation()
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
        // Coordinates for each location index
        switch (locationIndex)
        {
            case 0:
                return (5.81f, -1.38f);
            case 1:
                return (9.81f, -1.38f);
            case 2:
                return (13.81f, -1.38f);
            case 3:
                return (5.18f, 7.45f);
            case 4:
                return (9.18f, 7.45f);
            case 5:
                return (12.81f, 7.45f);
            default:
                return (0f, 0f);
        }
    }
}
