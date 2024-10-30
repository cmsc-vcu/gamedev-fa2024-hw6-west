using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public BulletPool bulletPool; // Reference to the bullet pool
    public float shootingCooldown = 0.5f; // Time between shots
    private float shootTimer = 0f; // Timer to track shooting cooldown
    public Transform shootPoint; // Point from which the bullet will be spawned

    private Vector2 movementDirection; // Variable to store movement direction

    void Update()
    {
        // Update the shoot timer
        shootTimer += Time.deltaTime;

        // Get movement input
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        // Check for shooting input (e.g., left mouse button)
        if (Input.GetButtonDown("Fire1") && shootTimer >= shootingCooldown)
        {
            Shoot();
            shootTimer = 0f; // Reset the shoot timer after shooting
        }
    }

    void Shoot()
    {
        // Check if the bullet pool is assigned
        if (bulletPool != null)
        {
            // Get a bullet from the pool
            GameObject bullet = bulletPool.GetBullet();
            bullet.transform.position = shootPoint.position; // Set bullet's spawn position
            bullet.GetComponent<BulletScript>().isEnemyBullet = false;
            bullet.SetActive(true); // Activate the bullet

            // If the player is not moving, default to the last direction
            if (movementDirection == Vector2.zero)
            {
                movementDirection = Vector2.down; // Use the shoot point's right direction if stationary
            }

            // Set bullet velocity in the movement direction
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bulletRB.velocity = movementDirection * bulletPool.bulletSpeed; // Ensure bulletSpeed is defined in BulletPool
        }
        else
        {
            Debug.LogWarning("Bullet pool reference is missing in PlayerShooting script.");
        }
    }
}
