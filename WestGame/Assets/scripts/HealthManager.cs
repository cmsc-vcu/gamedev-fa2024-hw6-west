using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject gameManager; // Reference to GameManager for win/lose menu
    public Image healthBar;
    public float healthAmount = 100f;
    public bool isPlayer; // Check if this is the player or enemy

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.Find("GameManager");
        }
    }

    void Update()
    {
        if (healthAmount <= 0)
        {
            if (isPlayer)
            {
                gameManager.GetComponent<GameManager>().PlayerLost(); // Lose screen
            }
            else
            {
                gameManager.GetComponent<GameManager>().PlayerWon(); // Win screen
            }
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HealingObject") && isPlayer)
        {
            Heal(20); // Amount to heal when colliding with HealingObject
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            TakeDamage(10); // Amount of damage from EnemyProjectile
        }
    }
}
