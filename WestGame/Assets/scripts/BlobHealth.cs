using UnityEngine;
using UnityEngine.UI;

public class BlobHealth : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public GameManager GameManager;
    private bool isDead;

    void Start()
    {
        maxHealth = health;
    }

    void Update() {

        if (health <= 0 && !isDead) {
            isDead = true;
            GameManager.PlayerWon();
            gameObject.SetActive(false);
            Debug.Log("enemy dead");
            
        }
    }
}
