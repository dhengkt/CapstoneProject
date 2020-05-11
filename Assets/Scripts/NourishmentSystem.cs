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

    [SerializeField] Sprite stage1;
    [SerializeField] Sprite stage2;
    [SerializeField] Sprite stage3;
    [SerializeField] Sprite stage4;
    private State currState;
    private int water, fertilizer;
    TimeSystem timeSystem;
    private int timeSegment;

    private void Start()
    {
        currState = State.Stage1;
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        timeSystem = door.GetComponent<TimeSystem>();
        timeSegment = timeSystem.GetTimeSegement();
        Debug.Log(timeSegment);
    }

    /*
     *  Need to do: change the condition of changing stage to time segement and find a way to
     *  let Game Manager has the access to values in this script.
     */
    private void Update()
    {
        // get SpriteRenderer to change sprite in different stage
        SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();

        switch (currState)
        {
            default:
            case State.Stage1:
                rend.sprite = stage1;
                // if water/fertilizer > 2, go to stage 2 and give another story to player
                if (water > 2 && fertilizer > 2)
                { 
                    currState = State.Stage2;
                }
                break;
            case State.Stage2:
                rend.sprite = stage2;
                // if water/fertilizer > 4, go to stage 2 and give another story to player
                if (water > 4 && fertilizer > 4)
                {
                    currState = State.Stage3;
                }
                break;
            case State.Stage3:
                rend.sprite = stage3;
                // if water/fertilizer > 6, go to stage 2 and give another story to player
                if (water > 6 && fertilizer > 6)
                {
                    currState = State.Stage4;
                }
                break;
            case State.Stage4:
                rend.sprite = stage4;
                // if water/fertilizer > 10, go to stage 2 and give another story to player
                // put the plant to the back table
                break;
        }
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
