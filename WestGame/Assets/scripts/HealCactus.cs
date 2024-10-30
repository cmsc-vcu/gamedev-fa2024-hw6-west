using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCactus : MonoBehaviour
{

    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Enemy bullet hits the player
            gameObject.SetActive(false);
            other.gameObject.GetComponent<PlayerHealth>().health += 20;
        }
    }
}
