using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    List<int> unusedStories = new List<int>() { 0, 1, 2 }; // Full list of unused story IDs
    List<int> usedStories = new List<int>(); // List of currently assigned story IDs
    int[] plantLocations = new int[6] { 0, 0, 0, 0, 0, 0 }; // 0: Vacant; 1: Occupied
    Plant[] currentPlants = new Plant[6]; // Keeps track of all plants currently in the game
    int numberOfPlants = 0;
    private GameObject firstPlant = null; // First plant in the game
    private Flowchart temFlowchart = null; // for assign flowchat to first plant


    // Start is called before the first frame update
    void Start()
    {
        firstPlant = Resources.Load<GameObject>("Prefabs/Plant");
       CreateFirstPlant();
    }

    // Update is called once per frame
    /*****Create plant should be called when the player reaches a certain time segment and goes outside*****/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            createPlant();
        }
    }

    /**
     * 
     * Need to find a way to create the flowchart object and add it to the plant create in this function
     * 
     **/
    private void CreateFirstPlant()
    {
        GameObject p = Instantiate(firstPlant);
        float x = 5.81f;
        float y = -1.38f;
        p.transform.position = new Vector3(x, y, -5f);
        numberOfPlants++;
        assignStory(p);
    }

    // Create a plant object before placing it in the game
    public void createPlant()
    {
        // Create and add plant to currentPlants[]
        Debug.Log("Creating Plant...");
        //currentPlants[numberOfPlants] = new Plant(assignStory(), assignOpenLocation());
        Debug.Log(currentPlants[numberOfPlants]);
        numberOfPlants += 1;
        Debug.Log("Unused Stories (after assign): " + unusedStories);
    }
    private int assignStory(GameObject plant)
    {
        Debug.Log("Unused Stories: " + unusedStories);
        UnityEngine.Random rnd = new UnityEngine.Random();
        int storyIndex = UnityEngine.Random.Range(0,unusedStories.Count);
        int tempStory = unusedStories[storyIndex];
        unusedStories.Remove(storyIndex);
        return 0;
    }
    private int assignOpenLocation()
    {
        return 0;
    }
    private void addToUsedStories()
    {

    }

}
