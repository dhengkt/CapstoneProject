using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    public Rigidbody2D rb;
    private Vector2 targetPoint;

   void Update()
    {
        targetPoint.x = Input.GetAxisRaw("Horizontal");
        targetPoint.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + targetPoint * moveSpeed * Time.fixedDeltaTime);
    }
}
