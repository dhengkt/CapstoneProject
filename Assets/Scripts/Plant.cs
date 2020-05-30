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

    public Flowchart flowchart;

    private string story;
    private Vector3 location;
    public bool plantTrigger;
    private int tempTimeSegment;
    private TimeSystem tSystem;
    private NourishmentSystem nSystem;
    private Player player;

    void Start()
    {
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        tSystem = door.GetComponent<TimeSystem>();
        nSystem = gameObject.GetComponent<NourishmentSystem>();
        plantMenu = FindObjectOfType<Canvas>();
        player = FindObjectOfType<Player>();
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (player.wAmount > 0)
                {
                    nSystem.AddWater();
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (player.fAmount > 0)
                {
                    nSystem.AddFertilizer();
                }
            }
        }
    }

    public void SetStory(int assignedStory)
    {
        // Assign story tag
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
        // if update time segment is true, then set temp time segment to current time segment and set update to false
        if (flowchart.GetBooleanVariable("updateTemp") == true)
        {
            this.tempTimeSegment = tSystem.tSegment; 
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
        pText.text = "In Stage " + nSystem.stageNum;
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
