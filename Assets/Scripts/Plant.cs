using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    // Set associated flowchart to plant
    public Flowchart flowchart;
    private string story;
    private Vector3 location;
    private bool plantTrigger; // plantTrigger is true if the player is touching the plant
    public Canvas actionMenu;
    private int water, fertilizer; 

    void Start()
    {
        //Debug.Log("Found flowchart: " + GameObject.FindObjectOfType<Flowchart>
    }

    void Update()
    {
        //Debug.Log("flowchart name: " + flowchart.GetName());
        //flowchart.SetIntegerVariable("story", this.story);
        //Debug.Log("Story for plant: " + flowchart.GetIntegerVariable("story"));
        // When player is touching plant and presses X, start
        if (plantTrigger && Input.GetKeyDown(KeyCode.X))
        {
            flowchart.ExecuteBlock("Start");
        }

    }

    public void SetStory(int assignedStory)
    {
        Debug.Log("Setting Story to: "+ assignedStory);
        // Assign story tag **add more story cases
        switch (assignedStory)
        {
            case 0:
                this.story = "Story 0";
                break;
            case 1:
                this.story = "Story 1";
                break;
            case 2:
                this.story = "Story 2";
                break;
            default:
                break;
        }
        Flowchart[] allFlowcharts = GameObject.FindObjectsOfType<Flowchart>();
        for (int i = 0; i < allFlowcharts.Length; i++)
        {
            if (allFlowcharts[i].gameObject.tag == this.story)
            {
                Debug.Log("Setting story to " + allFlowcharts[i]);
                this.flowchart = allFlowcharts[i];
            }
        }
        
        //flowchart.SetIntegerVariable("story", assignedStory); // Update flowchart story variable
        //Debug.Log("Flowchart story var: " + flowchart.GetIntegerVariable("story"));
    }
    public string GetStory()
    {
        return this.story;
    }

    public void SetLocation(float x, float y)
    {
        Debug.Log("Setting Location to: " + x +", " + y);
        this.location = new Vector3 (x, y, -5);
        transform.position = this.location;
    }

    public Vector3 GetLocation()
    {
        return this.location;
    }

    // Sync water and fetilizer variables to Flowchart's water and fertilizer variables
    public void SyncWaterAndFertilizer(int nSWater, int nSFertilizer) // nS: NourishmentSystem
    {
        flowchart.SetIntegerVariable("water", nSWater);
        flowchart.SetIntegerVariable("fertilizer", nSFertilizer);
        Debug.Log("Plant Setters- Water: " + flowchart.GetIntegerVariable("water") + " Fertilizer: " + flowchart.GetIntegerVariable("fertilizer"));
    }

    private void SetActionMenu(bool isTrigger)
    {
        actionMenu.gameObject.SetActive(isTrigger);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        plantTrigger = true;
        if (collision.gameObject.tag == "Player")
        {
            SetActionMenu(plantTrigger);
            Debug.Log("Touch");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        plantTrigger = false;
        SetActionMenu(plantTrigger);
    }

    public override string ToString()
    {
        return "Made Plant. Story: " + story + " Loc: " + location;
    }

}
