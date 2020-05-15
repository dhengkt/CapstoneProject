using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private TimeSystem tSystem;
    private PlayerActions pActions;
    private Flowchart tuFlowchart;

    /*
     * Tutorial Scene:
     * When game starts up, tutorial plant will spawn and tutorial dialogue will appear
     * Player talks to the tutorial plant and gives it water
     * Player finishes the reading the rest of the tutorial plant
     * Player leaves greenhouse and finds a new plant that replaces the tutorial plant
     */

    void Awake()
    {
        GameObject temDoor = Resources.Load<GameObject>("Prefabs/Door");
        GameObject door = Instantiate(temDoor);

        door.transform.position = new Vector3(-.23f, -7.99f, 0f);
        tSystem = door.GetComponent<TimeSystem>();
        pActions = door.GetComponent<PlayerActions>();

        tuFlowchart = FindObjectOfType<Flowchart>();
    }

    void Start()
    {
        CreateTutorialPlant();
    }

    void Update()
    {

    }

    private void CreateTutorialPlant()
    {
        Plant plant;
        GameObject p = Resources.Load<GameObject>("Prefabs/Plant");
        GameObject plantObject = Instantiate(p);
        plant = plantObject.GetComponent<Plant>();
        plant.transform.position = new Vector3(5.81f, -1.38f, -5f);

        plant.flowchart = tuFlowchart;
    }
}
