using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsMenu : MonoBehaviour
{
    public static bool goRiver = false;
    public static bool goForest = false;

    [SerializeField]
    private Canvas actionMenu;
    [SerializeField]
    private Sprite river;
    [SerializeField]
    private Sprite forest;

    private bool atDoor = false;
    private Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void SetMenu(bool trigger)
    {
        actionMenu.gameObject.SetActive(trigger);
    }

    public void GoToRiver()
    {
        goRiver = true;
        int temp = Random.Range(0, 6);

        // randomly give player water
        if (player.wAmount < 10)
        {
            // limit player's water amount to 10
            if (player.wAmount + temp > 10)
            {
                player.wAmount = 10;
            }
            else
            {
                player.wAmount += temp;
            }
        }
        goRiver = false;
    }

    public void GoToForest()
    {
        goForest = true;
        int temp = Random.Range(0, 6);

        // randomly give player fertilizer
        if (player.fAmount < 10)
        {
            // limit player's fertilizer amount to 10
            if (player.fAmount + temp > 10)
            {
                player.fAmount = 10;
            }
            else
            {
                player.fAmount += temp;
            }
        }
        goForest = false;
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
