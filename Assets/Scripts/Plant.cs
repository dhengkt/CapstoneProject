using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Plant : MonoBehaviour
{
    // Set associated flowchart to plant
    public Flowchart flowchart;
    private int water, fertilizer;
    private string story;
    private int stage;
    // plantTrigger is true if the player is touching the plant
    private bool plantTrigger;

    // Start is called before the first frame update
    void Start()
    {
        story = "Start";
        stage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(flowchart.);
        // When player is touching plant and presses X, start
        if (plantTrigger && Input.GetKeyDown(KeyCode.X))
        {
            flowchart.ExecuteBlock(story);
        }
    }

    private void ShowMenu()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        plantTrigger = true;
        if (collision.gameObject.tag == "Player")
        {
            ShowMenu();
            Debug.Log("Touch");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        plantTrigger = false;
    }
 
}
