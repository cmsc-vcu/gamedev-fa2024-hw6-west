using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    private bool isDestroyed = false;
    public bool isEnemyBullet;

    void OnEnable()  // Use OnEnable instead of Start to reuse the bullet from the pool
    {
        bulletRB = GetComponent<Rigidbody2D>();

        // Reset the destroyed flag when the bullet is reused
        isDestroyed = false;

        // Check if Rigidbody2D is assigned
        if (bulletRB == null)
        {
            Debug.LogError("Rigidbody2D is missing on the bullet.");
        }

        if (isEnemyBullet)
        {
            // Enemy bullet targets the player
            target = GameObject.FindGameObjectWithTag("Player");
        }

        else
        {
            bulletRB.velocity = transform.right * speed;  // Default direction
        }

        // Instead of destroying the bullet, we deactivate it after 2 seconds

        // Check if target (Player) exists
        if (target != null && isEnemyBullet)
        {
            Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        }

        Invoke("DeactivateBullet", 4f);
    }

    void DeactivateBullet()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            gameObject.SetActive(false);  // Deactivate instead of destroying
        }
    }

    // Optional: Handle collisions
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isEnemyBullet && other.gameObject.CompareTag("Player"))
        {
            // Enemy bullet hits the player
            gameObject.SetActive(false);
            other.gameObject.GetComponent<PlayerHealth>().health -= 10;
        }
        else if (!isEnemyBullet && other.gameObject.CompareTag("Enemy"))
        {
            // Player bullet hits the enemy
            gameObject.SetActive(false);
            other.gameObject.GetComponent<BlobHealth>().health -= 10;
            // Optional: Apply damage to the enemy here
        }
    }
}
