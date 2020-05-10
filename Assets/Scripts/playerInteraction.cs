using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class playerInteraction : MonoBehaviour
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
        //If player is touching/in front of plant, and presses space, then play plant flowchart
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flowchart.ExecuteBlock("Start");
        }

    }
}
