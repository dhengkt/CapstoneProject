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

    [SerializeField] Sprite stage1;
    [SerializeField] Sprite stage2;
    [SerializeField] Sprite stage3;
    [SerializeField] Sprite stage4;
    private State currState;
    private int water, fertilizer;
    TimeSystem timeSystem;
    private int timeSegment;

    private void Awake()
    {
        currState = State.Stage1;

        // get access of Time System script
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        timeSystem = door.GetComponent<TimeSystem>();
        timeSegment = timeSystem.GetTimeSegement();
    }

    private void Update()
    {
        // get SpriteRenderer to change sprite in different stage
        SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();

        switch (currState)
        {
            default:
            case State.Stage1:
                rend.sprite = stage1;
                GetTimeSegment();
                if (timeSegment == 6)
                { 
                    currState = State.Stage2;
                }
                break;
            case State.Stage2:
                rend.sprite = stage2;
                GetTimeSegment();
                if (water > 4 && fertilizer > 4)
                {
                    currState = State.Stage3;
                }
                break;
            case State.Stage3:
                rend.sprite = stage3;
                GetTimeSegment();
                if (water > 6 && fertilizer > 6)
                {
                    currState = State.Stage4;
                }
                break;
            case State.Stage4:
                rend.sprite = stage4;
                if (water > 8 || fertilizer > 8)
                {
                    gameObject.transform.position = new Vector3(5.18f, 7.45f, -5f);
                    //disable the ActionMenu of plant here
                }
                break;
        }
    }
    private int GetTimeSegment()
    {
        timeSegment = timeSystem.GetTimeSegement();
        return timeSegment;
    }
    public void AddWater()
    {
        // check if player has enough water
        water++;
        Debug.Log(water);
    }

    public void AddFertilizer()
    {
        // check if player has enough fertilizer
        fertilizer++;
        Debug.Log(fertilizer);
    }
}
