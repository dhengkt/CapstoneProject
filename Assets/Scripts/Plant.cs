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
    private int stage;
    // plantTrigger is true if the player is touching the plant
    private bool plantTrigger;
    public Canvas actionMenu;

    // Start is called before the first frame update
    void Start()
    {
        story = "Start";
        stage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(flowchart);
        // When player is touching plant and presses X, start
        if (plantTrigger && Input.GetKeyDown(KeyCode.X))
        {
            flowchart.ExecuteBlock(story);
        }

    }

    private void SetActionMenu(bool isTrigger)
    {
        Debug.Log("Show Menu");
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
 
}
