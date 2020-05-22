using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private TimeSystem tSystem;
    private ActionsMenu pActions;
    private Flowchart tuFlowchart;
    private Player player;
    private Plant plant;
    private NourishmentSystem nSystem;
    private bool isDone = false;

    /*
     * Tutorial Scene:
     * When game starts up, tutorial plant will spawn and tutorial dialogue will appear
     * Player talks to the tutorial plant and gives it water
     * Player finishes the reading the rest of the tutorial plant
     * Player leaves greenhouse and finds a new plant that replaces the tutorial plant
     */

    void Awake()
    {
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        door.transform.position = new Vector3(-.23f, -7.99f, 0f);
        tSystem = door.GetComponent<TimeSystem>();
        pActions = door.GetComponent<ActionsMenu>();
        tuFlowchart = FindObjectOfType<Flowchart>();
        tuFlowchart.SetBooleanVariable("isDone", false);

        player = GameObject.FindObjectOfType<Player>();
    }

    void Start()
    {
        Debug.Log(tuFlowchart.GetVariable("isDone"));
        player.fAmount = 2;
        player.wAmount = 3;
        tSystem.isTutorial = true;
        GameObject p = Resources.Load<GameObject>("Prefabs/Plant");
        GameObject plantObject = Instantiate(p);
        plant = plantObject.GetComponent<Plant>();
        plant.transform.position = new Vector3(5.81f, -1.38f, -5f);
        plant.flowchart = tuFlowchart;
        nSystem = plant.GetComponent<NourishmentSystem>();
        plant.SyncWaterAndFertilizer(nSystem.water, nSystem.fertilizer);
    }

    void Update()
    {
        plant.SyncWaterAndFertilizer(nSystem.water, nSystem.fertilizer);
        if (Input.GetKeyDown(KeyCode.X))
        {
            tSystem.isTutorial = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
