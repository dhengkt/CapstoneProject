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
    public int plantNumber;
    public int stageNum;
    public float lifetime;

    private State currState;
    private TimeSystem tSystem;
    private Plant pScript;
    private Flowchart pFlowchart;
    private Canvas plMenu;
    private Player player;
    private int passedTime;
    private int createdTime;

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
        stageNum = 0;
        createdTime = tSystem.tSegment;
        Debug.Log(createdTime);
        passedTime = tSystem.tSegment - createdTime;
        Debug.Log(passedTime);
    }

    void Update()
    {
        int curTime = tSystem.tSegment;
        passedTime = curTime - createdTime;
        ChangeStage();
        Debug.Log(passedTime);
    }

    private void ChangeStage()
    {
        SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();

        switch (currState)
        {
            default:
            case State.Stage1:
                rend.sprite = stage1;
                if (passedTime == 1)
                {
                    currState = State.Stage2;
                    stageNum = 1;
                }
                break;
            case State.Stage2:
                rend.sprite = stage2;
                if (passedTime == 2)
                {
                    currState = State.Stage3;
                    stageNum = 2;
                }
                break;
            case State.Stage3:
                rend.sprite = stage3;
                if (passedTime == 3)
                {
                    currState = State.Stage4;
                    stageNum = 3;
                }
                break;
            case State.Stage4:
                rend.sprite = stage4;
                if (passedTime == 4)
                {
                }
                break;
        }
        // update plant's water and fertilizer to match flowchart
        pScript.SyncWaterAndFertilizer(water, fertilizer);
    }

    public void AddWater()
    {
        if (player.wAmount > 0)
        {
            water++;
            player.wAmount--;
        }
    }

    public void AddFertilizer()
    {
        if (player.fAmount > 0)
        {
            fertilizer++;
            player.fAmount--;
        }
    }
}
