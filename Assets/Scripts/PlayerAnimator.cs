using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plays Player watering and fertilizing animation
public class PlayerAnimator : MonoBehaviour
{
    public Player player;
    public Animator animator;

    void Update()
    {
        if (Input.GetButtonDown("Water") && player.wAmount > 0)
        {
            FindObjectOfType<AudioManager>().Play("AddWater");
            player.GetComponent<Animator>().Play("Player_Watering");
        }
        if (Input.GetButtonDown("Fertilize") && player.fAmount > 0)
        {
            FindObjectOfType<AudioManager>().Play("AddFertilizer");
            player.GetComponent<Animator>().Play("Player_Fertilize");
        }
    }
}
