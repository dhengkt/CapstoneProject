using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    // Set associated flowchart to plant
    public Flowchart flowchart;
    private int story;
    private Vector3 location;
    private bool plantTrigger; // plantTrigger is true if the player is touching the plant
    public Canvas actionMenu;

    void Start()
    {
        //Debug.Log("Found flowchart: " + GameObject.FindObjectOfType<Flowchart>());
        this.flowchart = GameObject.FindObjectOfType<Flowchart>(); // Finds the root
    }

    void Update()
    {
        //Debug.Log("flowchart name: " + flowchart.GetName());
        //flowchart.SetIntegerVariable("story", this.story);
        //Debug.Log("Story for plant: " + flowchart.GetIntegerVariable("story"));
        // When player is touching plant and presses X, start
        if (plantTrigger && Input.GetKeyDown(KeyCode.X))
        {
            flowchart.ExecuteBlock("Assign a Story");
        }

    }

    public void setStory(int assignedStory)
    {
        Debug.Log("Setting Story to: "+ assignedStory);
        this.story = assignedStory;
    }
    public int getStory()
    {
        return this.story;
    }

    public void setLocation(float x, float y)
    {
        Debug.Log("Setting Location to: " + x +", " + y);
        this.location = new Vector3 (x, y, -5);
        transform.position = this.location;
    }

    public Vector3 getLocation()
    {
        return this.location;
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
