using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    float vertical;
    float horizontal;

    public float speedLimit;
    public float moveSpeed;

    // Sprites for movement frames
    public Sprite idleSprite;
    public Sprite[] rightSprites;
    public Sprite[] leftSprites;
    public Sprite[] upSprites;
    public Sprite[] downSprites;
    

    private int currentFrame;
    private float frameTime = 0.3f; // Time between frame changes
    private float timeSinceLastFrame;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentFrame = 0; // Start with the first sprite in the array
        timeSinceLastFrame = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= speedLimit;
            vertical *= speedLimit;
        }

        // Move the character
        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);

        // Check if the player is moving
        if (horizontal != 0 || vertical != 0)
        {
            // Cycle through the moving sprites
            timeSinceLastFrame += Time.fixedDeltaTime;
            if (timeSinceLastFrame >= frameTime && horizontal > 0)
            {
                currentFrame = (currentFrame + 1) % rightSprites.Length; // Loop through sprites
                spriteRenderer.sprite = rightSprites[currentFrame];
                timeSinceLastFrame = 0f; // Reset time
            }

            else if (timeSinceLastFrame >= frameTime && horizontal < 0)
            {
                currentFrame = (currentFrame + 1) % leftSprites.Length; // Loop through sprites
                spriteRenderer.sprite = leftSprites[currentFrame];
                timeSinceLastFrame = 0f; // Reset time
            }
            else if (timeSinceLastFrame >= frameTime && horizontal < 0 && vertical != 0)
            {
                currentFrame = (currentFrame + 1) % leftSprites.Length; // Loop through sprites
                spriteRenderer.sprite = leftSprites[currentFrame];
                timeSinceLastFrame = 0f; // Reset time
            }
            else if (timeSinceLastFrame >= frameTime && horizontal > 0 && vertical != 0)
            {
                currentFrame = (currentFrame + 1) % rightSprites.Length; // Loop through sprites
                spriteRenderer.sprite = rightSprites[currentFrame];
                timeSinceLastFrame = 0f; // Reset time
            }

            else if (timeSinceLastFrame >= frameTime && vertical > 0)
            {
                currentFrame = (currentFrame + 1) % upSprites.Length; // Loop through sprites
                spriteRenderer.sprite = upSprites[currentFrame];
                timeSinceLastFrame = 0f; // Reset time
            }

            else if (timeSinceLastFrame >= frameTime && vertical < 0)
            {
                currentFrame = (currentFrame + 1) % downSprites.Length; // Loop through sprites
                spriteRenderer.sprite = downSprites[currentFrame];
                timeSinceLastFrame = 0f; // Reset time
            }
        }
        else
        {
            // Set to idle sprite when not moving
            spriteRenderer.sprite = idleSprite;
        }
    }

 /*   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            cm.collectibleCount++;
        }
    } */
}