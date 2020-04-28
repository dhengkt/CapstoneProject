using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Plant : MonoBehaviour
{
    // Set associated flowchart to plant
    public Flowchart flowchart;
    // plantTrigger is true if the player is touching the plant
    private bool plantTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plantTrigger && Input.GetKeyDown(KeyCode.X))
        {
            flowchart.ExecuteBlock("Start");
        }
    }

    private void ShowMeun()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        plantTrigger = true;
        if (collision.gameObject.tag == "Player")
        {
            ShowMeun();
            Debug.Log("Touch");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        plantTrigger = false;
    }
 
}
