using Fungus;
using System.Collections;
using System.Collections.Generic;
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

    public int water, fertilizer = 0;
    public int needWater, needFertilizer;
    public int plantNumber;
    public int stageNum;
    public float lifetime;
    private State currState;
    private TimeSystem tSystem;
    private Plant pScript;
    private Flowchart pFlowchart;
    private Canvas plMenu;
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
        plMenu = pScript.plantMenu;
    }

     void Start()
    {
        // Sync water and fertilizer variables (0) with plant flowchart
        pScript.SyncWaterAndFertilizer(water, fertilizer);
        currState = State.Stage1;
        needWater = 1;
        needFertilizer = 1;
        stageNum = 0;
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
                if (water == 1 && fertilizer == 1 && currState == State.Stage1)
                {
                    currState = State.Stage2;
                    stageNum = 1;
                    needWater = 2;
                    needFertilizer = 2;
                    water = 0;
                    fertilizer = 0;
                }
                break;
            case State.Stage2:
                rend.sprite = stage2;
                // need to reset the condition
                if (water  == 2 && fertilizer == 2 && currState == State.Stage2)
                {
                    currState = State.Stage3;
                    stageNum = 2;
                    needWater = 4;
                    needFertilizer = 3;
                    water = 0;
                    fertilizer = 0;
                }
                break;
            case State.Stage3:
                rend.sprite = stage3;
                if (water  == 4 && fertilizer == 3 && currState == State.Stage3)
                {
                    currState = State.Stage4;
                    stageNum = 3;
                    needWater = 6;
                    needFertilizer = 4;
                    water = 0;
                    fertilizer = 0; 
                }
                break;
            case State.Stage4:
                rend.sprite = stage4;
                if (water == 6 &&  fertilizer == 4&& currState == State.Stage4)
                {
                    ////move the plant to backtable
                    //if (plantNumber > 3)
                    //{
                    //    // don't move position
                    //}
                    //else
                    //{
                    //    if (plantNumber == 1)
                    //    {
                    //        gameObject.transform.position = new Vector3(5.49f, 7.64f, -5f);
                    //    }
                    //    if (plantNumber == 2)
                    //    {
                    //        gameObject.transform.position = new Vector3(9.12f, 7.64f, -5f);
                    //    }
                    //    if (plantNumber == 3)
                    //    {
                    //        gameObject.transform.position = new Vector3(12.75f, 7.64f, -5f);
                    //    }
                    //}
                    //disable the plant info of plant here
                    plMenu.gameObject.SetActive(false);
                }
                break;
        }
        // update plant's water and fertilizer to match flowchart
        pScript.SyncWaterAndFertilizer(water, fertilizer);
    }

    public void AddWater()
    {
        // check if player has enough water
        if (player.wAmount > 0 && needWater > 0)
        {
            water++;
            needWater--;
            player.wAmount--;
            Debug.Log(water);
        }
    }

    public void AddFertilizer()
    {
        // check if player has enough fertilizer
        if (player.fAmount > 0 && needFertilizer > 0)
        {
            fertilizer++;
            needFertilizer--;
            player.fAmount--;
            Debug.Log(fertilizer);
        }
    }
}
