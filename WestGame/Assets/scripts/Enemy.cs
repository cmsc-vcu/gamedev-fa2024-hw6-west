using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float lineOfSight;
    public float shootingRange;
    private Transform player;
    public GameObject bullet;
    public GameObject bulletParent;
    public BulletPool bulletPool;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public GameObject enemy;  // Ensure this is assigned in the Inspector
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure player still exists before continuing
        if (player == null) return;

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        // Move towards the player if within line of sight
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange) {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime); 
        }
        else if (distanceFromPlayer <= shootingRange) {
            if (bulletPool == null || enemy == null)
        {
            Debug.LogWarning("Bullet or Enemy reference is missing, cannot instantiate bullet.");
            return;  // Exit the update loop if references are missing
        }


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
            bullet.GetComponent<BulletScript>().isEnemyBullet = true;
            bullet.SetActive(true);  // Activate the bullet
        }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}