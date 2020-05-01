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

    private void Awake()
    {
        currState = State.Stage1;
    }

    private void Start()
    {
        
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
                // if water/fertilizer > 2, go to stage 2 and give another story to player
                if (water > 2 && fertilizer >2)
                {
                    currState = State.Stage2;
                }
                break;
            case State.Stage2:
                rend.sprite = stage2;
                // if water/fertilizer > 4, go to stage 2 and give another story to player
                break;
            case State.Stage3:
                rend.sprite = stage3;
                // if water/fertilizer > 6, go to stage 2 and give another story to player
                break;
            case State.Stage4:
                rend.sprite = stage4;
                // if water/fertilizer > 10, go to stage 2 and give another story to player
                break;
        }
    }

    public void AddWater()
    {
        water++;
        Debug.Log(water);
    }

    public void AddFertilizer()
    {
        fertilizer++;
        Debug.Log(fertilizer);
    }

}
