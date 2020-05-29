using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public GameObject player; 
    void Update()
    {
        if (Input.GetButtonDown("Water"))
        {
            player.GetComponent<Animator>().Play("Player_Watering");
        }
        if (Input.GetButtonDown("Fertilize"))
        {
            player.GetComponent<Animator>().Play("Player_Fertilize");
        }
    }
}
