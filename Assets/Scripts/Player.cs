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

    private Plant plant;
    private SpriteRenderer sRenderer;
    private Sprite alienDefault, alienFertilize, alienWater;

    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        alienDefault = Resources.Load<Sprite>("alien-front1");
        alienFertilize = Resources.Load<Sprite>("Alien Fertilize");
        alienWater = Resources.Load<Sprite>("Alien Water");
    }

    void Update()
    {
        // Player movement
        targetPoint.x = Input.GetAxisRaw("Horizontal");
        targetPoint.y = Input.GetAxisRaw("Vertical");
        // Player Sprite Animator
        animator.SetFloat("Horizontal", targetPoint.x);
        animator.SetFloat("Vertical", targetPoint.y);
        animator.SetFloat("Speed", targetPoint.sqrMagnitude);
        if (plant.plantTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F)) //fert
            {
                sRenderer.sprite = alienFertilize;
                Debug.Log("FERTILIZE SPRITE");
            }
            if (Input.GetKeyDown(KeyCode.E)) //water
            {
                sRenderer.sprite = alienWater;
                Debug.Log("WATER SPRITE");
            }
            else
            {
                sRenderer.sprite = alienDefault;
            }
        }
    }
    public void PlaySprite()
    {

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + targetPoint * moveSpeed * Time.fixedDeltaTime);
    }
}
