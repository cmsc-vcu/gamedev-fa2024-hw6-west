using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    public BulletPool bulletPool;  // Ensure this is assigned in the Inspector
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public GameObject enemy;  // Ensure this is assigned in the Inspector
    public GameObject player;
    private float rotZ;
    private Vector3 rotation;
    public float speed;

    void Update()
    {
        // Check if bulletPool and enemy references are missing
        if (bulletPool == null || enemy == null)
        {
            Debug.LogWarning("Bullet or Enemy reference is missing, cannot instantiate bullet.");
            return;  // Exit the update loop if references are missing
        }

        // Rotate the enemy to face the player
       /* rotation = player.transform.position - transform.position;
        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);*/

        // Manage firing rate
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        // Fire the bullet if allowed
        if (canFire)
        {
            canFire = false;
            GameObject bullet = bulletPool.GetBullet();  // Get a bullet from the pool
            bullet.transform.position = enemy.transform.position;  // Set bullet's spawn position
            bullet.SetActive(true);  // Activate the bullet
        }
    }
}
