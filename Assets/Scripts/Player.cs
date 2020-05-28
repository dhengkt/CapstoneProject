using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    [HideInInspector]
    public int wAmount = 3;
    [HideInInspector]
    public int fAmount = 2;

    private Vector2 targetPoint;
    private int x;
    
   void Update()
    {
        // Player movement
        targetPoint.x = Input.GetAxisRaw("Horizontal");
        targetPoint.y = Input.GetAxisRaw("Vertical");
        // Player Sprite Animator
        animator.SetFloat("Horizontal", targetPoint.x);
        animator.SetFloat("Vertical", targetPoint.y);
        animator.SetFloat("Speed", targetPoint.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + targetPoint * moveSpeed * Time.fixedDeltaTime);
    }
}
