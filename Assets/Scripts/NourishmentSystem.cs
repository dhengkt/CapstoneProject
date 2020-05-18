using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class NourishmentSystem : MonoBehaviour
{
    private enum State
    {
        Stage1,
        Stage2,
        Stage3,
        Stage4,
    }

    [SerializeField]
    private Sprite stage1;
    [SerializeField]
    private Sprite stage2;
    [SerializeField]
    private Sprite stage3;
    [SerializeField]
    private Sprite stage4;

    private State currState;
    public int water, fertilizer = 0; // Set water and fertilizer to 0
    private TimeSystem tSystem;
    private Plant pScript;
    private Flowchart pFlowchart;
    private Canvas actMenu;
    private Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        // Get access to Time System script
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        tSystem = door.GetComponent<TimeSystem>();

        // Get access to Plant script
        pScript = gameObject.GetComponent<Plant>();
        pFlowchart = gameObject.GetComponent<Flowchart>();
        actMenu = pScript.actionMenu;
    }

     void Start()
    {
        currState = State.Stage1;

        // Sync water and fertilizer variables (0) with plant flowchart
        pScript.SyncWaterAndFertilizer(water, fertilizer);
    }

    void Update()
    {
        // Get SpriteRenderer to change sprite in different stage
        SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();

        switch (currState)
        {
            default:
            case State.Stage1:
                rend.sprite = stage1;
                if (tSystem.tSegment == 6)
                {
                    currState = State.Stage2;
                }
                break;
            case State.Stage2:
                rend.sprite = stage2;
                // need to reset the condition
                if (water > 4 && fertilizer > 4)
                {
                    currState = State.Stage3;
                }
                break;
            case State.Stage3:
                rend.sprite = stage3;
                // need to reset the condition
                if (water > 6 && fertilizer > 6)
                {
                    currState = State.Stage4;
                }
                break;
            case State.Stage4:
                rend.sprite = stage4;
                // need to reset the condition
                if (water > 8 && fertilizer > 8)
                {
                    //move the plant to backtable
                    gameObject.transform.position = new Vector3(5.18f, 7.45f, -5f);
                    //disable the Action Menu of plant here
                    actMenu.gameObject.SetActive(false);
                }
                break;
        }
        // update plant's water and fertilizer to match flowchart
        pScript.SyncWaterAndFertilizer(water, fertilizer);
    }

    public void AddWater()
    {
        // check if player has enough water
        if (player.wAmount > 0)
        {
            water++;
            player.wAmount--;
            Debug.Log(water);
        }
    }

    public void AddFertilizer()
    {
        // check if player has enough fertilizer
        if (player.fAmount > 0)
        {
            fertilizer++;
            player.fAmount--;
            Debug.Log(fertilizer);
        }
    }

    // Sync water and fetilizer variables to Flowchart's water and fertilizer variables
    // This function is also in Plant.cs we will decide which one to use later on
    private void SyncWaterAndFertilizer(int nSWater, int nSFertilizer)
    {
        pFlowchart.SetIntegerVariable("water", nSWater);
        pFlowchart.SetIntegerVariable("fertilizer", nSFertilizer);
        Debug.Log("Plant Setters- Water: " + pFlowchart.GetIntegerVariable("water") + " Fertilizer: " + pFlowchart.GetIntegerVariable("fertilizer"));
    }
}
