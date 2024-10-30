using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public GameManager GameManager;
    private bool isDead;
    public Image healthBar;

    void Start()
    {
        maxHealth = health;
    }

    void Update() {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0 && !isDead) {
            isDead = true;
            GameManager.PlayerLost();
            gameObject.SetActive(false);
            Debug.Log("dead");
        }
    }
}
