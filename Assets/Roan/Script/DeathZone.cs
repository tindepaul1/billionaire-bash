using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Health playerHealth;
    public Health2 playerHealth2;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(100);
                Debug.Log($"Player hit! Damage applied: {100}");
            }

            else
            {
                Debug.Log("Health script not found on player.");
            }
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            Health2 playerHealth2 = collision.gameObject.GetComponent<Health2>();
            if (playerHealth2 != null)
            {
                playerHealth2.EnterDamage(100);
                Debug.Log($"Player hit! Damage applied: {100}");
            }

            else
            {
                Debug.Log("Why?");
            }
        }
        else
        {
            Destroy(collision.gameObject);
            Debug.Log("Object destroyed");
        }
    }
}
