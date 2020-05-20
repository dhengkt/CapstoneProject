using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsMenu : MonoBehaviour
{

    [SerializeField]
    private Canvas actionMenu;
    [SerializeField]
    private Sprite river;
    [SerializeField]
    private Sprite forest;

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
        if (player.wAmount < 4 || player.fAmount < 4)
        {
            int temp = Random.Range(0, 4);
            int temp2 = Random.Range(0, 4);

            if (player.fAmount + temp > 4 || player.wAmount + temp2 > 4)
            {
                player.fAmount = 4;
                player.wAmount = 4;
            }
            else
            {
                player.fAmount += temp;
                player.wAmount += temp2;
            }
        }

    }

    public void GoToRiver()
    {

    }

    public void GoToForest()
    {

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
