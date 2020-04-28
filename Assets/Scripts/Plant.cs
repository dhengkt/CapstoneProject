using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Plant : MonoBehaviour
{
    // Set associated flowchart to plant
    public Flowchart flowchart;
    private bool plantTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowMeun()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ShowMeun();
            Debug.Log("Touch");
        }
    }
    //if player is on the square in front of a plant and presses x, trigger that plant's dialogue
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Staying");
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Talk");
            flowchart.ExecuteBlock("Start");
           
        }
    }

}
