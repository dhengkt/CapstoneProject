using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Plant : MonoBehaviour
{
    // Set associated flowchart to plant
    public Flowchart flowchart;
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
        //If player is touching/in front of plant, and presses space, then start plant flowchart
        if (collision.gameObject.tag == "Player")
        {
            ShowMeun();
            Debug.Log("Touch");
           
            //flowchart.ExecuteBlock("Start");
            
        }
    }
}
