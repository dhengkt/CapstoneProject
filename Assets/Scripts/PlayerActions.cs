using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Canvas actionMenu;
    private bool atDoor = false;
    TimeSystem tSystem;

    void Awake()
    {
        tSystem = gameObject.GetComponent<TimeSystem>();
    }

    void Update()
    {
        if (tSystem.GetTimeSegement() == 21)
        {
            actionMenu.gameObject.SetActive(false);
        }
    }

    public void SetMenu(bool trigger)
    {
        actionMenu.gameObject.SetActive(trigger);
    }

    public void ChooseGather()
    {
        // random give player certain amount of water/fertilizer
    }

    public void GoToRiver()
    {
        //
    }

    public void GoToForest()
    {
        //
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        atDoor = true;
        if (collision.gameObject.tag == "Player")
        {
            SetMenu(atDoor);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        atDoor = false;
        SetMenu(atDoor);
    }
}
