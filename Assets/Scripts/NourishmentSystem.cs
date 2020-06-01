using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Nourishment System for plant
 * Control the stage change, keep track with the amount of water/fertilizer
 * Link with Plant, Player, Time System, and Stage Effect script to have access to get needed info
 */
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

    [HideInInspector]
    public int water, fertilizer = 0;
    [HideInInspector]
    public int plantNumber;
    [HideInInspector]
    public int stageNum;

    private int passedTime;
    private int createdTime;
    private Plant pScript;
    private Player player;
    private State currState;
    private TimeSystem tSystem;
    private StageEffect sEffect;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        sEffect = gameObject.GetComponent<StageEffect>();

        // Get access to Time System script
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        tSystem = door.GetComponent<TimeSystem>();

        // Get access to Plant script
        pScript = gameObject.GetComponent<Plant>();
    }

     void Start()
    {
        pScript.SyncWaterAndFertilizer(water, fertilizer);
        currState = State.Stage1;
        stageNum = 1;
        createdTime = tSystem.tSegment;
        passedTime = tSystem.tSegment - createdTime;
    }

    void Update()
    {
        int curTime = tSystem.tSegment;
        passedTime = curTime - createdTime;
        SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();

        switch (currState)
        {
            default:
            case State.Stage1:
                rend.sprite = stage1;
                if (passedTime == 1)
                {
                    currState = State.Stage2;
                    sEffect.Upgrade();
                    FindObjectOfType<AudioManager>().Play("StageSwitch");
                    stageNum = 1;
                }
                break;
            case State.Stage2:
                rend.sprite = stage2;
                if (passedTime == 2)
                {
                    currState = State.Stage3;
                    sEffect.Upgrade();
                    FindObjectOfType<AudioManager>().Play("StageSwitch");
                    stageNum = 2;
                }
                break;
            case State.Stage3:
                rend.sprite = stage3;
                if (passedTime == 4)
                {
                    currState = State.Stage4;
                    sEffect.Upgrade();
                    FindObjectOfType<AudioManager>().Play("StageSwitch");
                    stageNum = 3;
                }
                break;
            case State.Stage4:
                rend.sprite = stage4;
                if (passedTime == 8)
                {
                    stageNum = 4;
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
