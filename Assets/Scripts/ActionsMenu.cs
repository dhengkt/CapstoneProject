using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsMenu : MonoBehaviour
{

    [SerializeField]
    private Canvas actionMenu;
    private bool atDoor = false;
    private Player player;
    private int water, fertilizer;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void SetMenu(bool trigger)
    {
        actionMenu.gameObject.SetActive(trigger);
    }

    public void GatherResources()
    {
        // random give player certain amount of water/fertilizer
        if (player.wAmount < 4 && player.fAmount < 4)
        {
        }
    }

    public void GoToRiver() { }

    public void GoToForest() { }

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
