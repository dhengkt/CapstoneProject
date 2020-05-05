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

    
    // Start is called before the first frame update
    void Start()
    {
       
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

    // Create a plant object before placing it in the game
    public void createPlant()
    {
        // Create and add plant to currentPlants[]
        Debug.Log("Creating Plant...");
        currentPlants[numberOfPlants] = new Plant(assignStory(), assignOpenLocation());
        Debug.Log(currentPlants[numberOfPlants]);
        numberOfPlants += 1;
        Debug.Log("Unused Stories (after assign): " + unusedStories);
    }
    private int assignStory()
    {
        Debug.Log("Unused Stories: " + unusedStories);
        Random rnd = new Random();
        int storyIndex = Random.Range(0,unusedStories.Count);
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
