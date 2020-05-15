using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 5f;

    public Rigidbody2D rb;
    private Vector2 targetPoint;
    public Animator animator;
    private int x;
    public int wAmount, fAmount = 0;
    

   void Update()
    {
        // Player movement
        targetPoint.x = Input.GetAxisRaw("Horizontal");
        targetPoint.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", targetPoint.x);
        animator.SetFloat("Vertical", targetPoint.y);
        animator.SetFloat("Speed", targetPoint.sqrMagnitude);


        //if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0){
        //    animator.SetFloat("speed", 0);
        //}
        //else{
        //    animator.SetFloat("speed", 1);
        //}
        
        //if down, then set bool to positive
        //if (Input.GetAxisRaw("Vertical") < 0){ 
        //    animator.SetBool("Front", true);
        //}
        //else
        //{
        //    animator.SetBool("Front", false);
        //}
        //if (Input.GetAxisRaw("Vertical") > 0)
        //{
        //    animator.SetBool("Back", true);
        //}
        //else
        //{
        //    animator.SetBool("Back", false);
        //}
        //if (Input.GetAxisRaw("Horizontal") < 0)
        //{
        //    animator.SetBool("Side", true);
        //}
        //else
        //{
        //    animator.SetBool("Side", false);
        //}

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + targetPoint * moveSpeed * Time.fixedDeltaTime);
    }
}
