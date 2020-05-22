using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField]
    public Canvas plantMenu;
    [SerializeField]
    public Text pText;
    [SerializeField]
    public NourishmentSystem nourSystem;

    // Set associated flowchart to plant
    public Flowchart flowchart;
    private string story;
    private Vector3 location;
    private bool plantTrigger; // plantTrigger is true if the player is touching the plant
    private int tempTimeSegment;
    private TimeSystem tSystem;
    private NourishmentSystem nSystem;

    void Start()
    {
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        tSystem = door.GetComponent<TimeSystem>();
        nSystem = gameObject.GetComponent<NourishmentSystem>();

        plantMenu = FindObjectOfType<Canvas>();
    }

    void Update()
    {
        SetActionMenu(plantTrigger);
        if (plantTrigger)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                flowchart.ExecuteBlock("Start");
                UpdateTimeSegement();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (nourSystem.needWater != 0)
                {
                    nourSystem.AddWater();
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (nourSystem.needFertilizer != 0)
                {
                    nourSystem.AddFertilizer();
                }
            }
        }
    }

    public void SetStory(int assignedStory)
    {
        Debug.Log("Setting Story to: "+ assignedStory);
        // Assign story tag **add more story cases
        switch (assignedStory)
        {
            case 0:
                this.story = "Story 0";
                break;
            case 1:
                this.story = "Story 1";
                break;
            case 2:
                this.story = "Story 2";
                break;
            case 3:
                this.story = "Story 3";
                break;
            case 4:
                this.story = "Story 4";
                break;
            default:
                break;
        }
        // Assign the appropriate flowchart 
        Flowchart[] allFlowcharts = GameObject.FindObjectsOfType<Flowchart>();
        for (int i = 0; i < allFlowcharts.Length; i++)
        {
            if (allFlowcharts[i].gameObject.tag == this.story)
            {
                Debug.Log("Setting story to " + allFlowcharts[i]);
                this.flowchart = allFlowcharts[i];
            }
        }
        //flowchart.SetIntegerVariable("story", assignedStory); // Update flowchart story variable
        //Debug.Log("Flowchart story var: " + flowchart.GetIntegerVariable("story"));
    }

    public string GetStory()
    {
        return this.story;
    }

    public void SetLocation(float x, float y)
    {
        Debug.Log("Setting Location to: " + x +", " + y);
        this.location = new Vector3 (x, y, -5);
        transform.position = this.location;
    }

    public Vector3 GetLocation()
    {
        return this.location;
    }

    // Sync water and fetilizer variables to Flowchart's water and fertilizer variables
    public void SyncWaterAndFertilizer(int nSWater, int nSFertilizer) // nS: NourishmentSystem
    {
        flowchart.SetIntegerVariable("water", nSWater);
        flowchart.SetIntegerVariable("fertilizer", nSFertilizer);
    }

    private void UpdateTimeSegement()
    {
        //if update time segment is true, then set temp time segment to current time segment and set update to false
        Debug.Log("***UPDATE TEMP: " + flowchart.GetBooleanVariable("updateTemp"));
        Debug.Log("Temp Time Seg: " + this.tempTimeSegment);
        //Debug.Log("Current Seg: " + this.tSystem.tSegment); 
        if (flowchart.GetBooleanVariable("updateTemp") == true)
        {
            this.tempTimeSegment = tSystem.tSegment; // ERROR
            flowchart.SetBooleanVariable("updateTemp", false);
            Debug.Log("***Temp FALSE?: " + flowchart.GetBooleanVariable("updateTemp"));
        }
        //if current time segment is more than temp time segment, set movetoNext (stage) to true and update time segment to true
        if (tSystem.tSegment > this.tempTimeSegment)
        {
            flowchart.SetBooleanVariable("moveToNext", true);
        }
        //if current time segment is less than or equal to temp time segment, set move to next to false
        else
        {
            flowchart.SetBooleanVariable("moveToNext", false);
        }

        if (flowchart.GetBooleanVariable("moved") == true)
        {
            flowchart.SetBooleanVariable("moveToNext", false); //set moveToNext to false (while on the same time segment) once the story stage has moved forward
            flowchart.SetBooleanVariable("moved", false);

        }
    }

    private void SetActionMenu(bool isTrigger)
    {
        plantMenu.gameObject.SetActive(isTrigger);
        UpdateText();
    }

    private void UpdateText()
    {
        pText.text = "Stage " + nourSystem.stageNum + "\nNeed " + nourSystem.needWater + " water" + " \nNeed " + nourSystem.needFertilizer  + " fertilizer";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            plantTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        plantTrigger = false;
    }

    public override string ToString()
    {
        return "Made Plant. Story: " + story + " Loc: " + location;
    }
}
