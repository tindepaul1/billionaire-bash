using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public float maxDistance;
    public float damage = 20f;
    private Vector2 spawnPosition;

    void Start()
    {
        spawnPosition = transform.position;
    }

    void Update()
    {
        float distanceTraveled = Vector2.Distance(spawnPosition, transform.position);

        // Destroy the bullet if it has traveled the maximum allowed distance
        if (distanceTraveled >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bullet collided with: " + collision.gameObject.name);

        // Check if the object has a Health component (Player 1)
        Health playerHealth1 = collision.gameObject.GetComponent<Health>();
        if (playerHealth1 != null)
        {
            playerHealth1.TakeDamage(damage);
            Debug.Log($"Player 1 hit! Damage applied: {damage}");
        }

        // Check if the object has a Health2 component (Player 2)
        Health2 playerHealth2 = collision.gameObject.GetComponent<Health2>();
        if (playerHealth2 != null)
        {
            playerHealth2.EnterDamage(damage);
            Debug.Log($"Player 2 hit! Damage applied: {damage}");
        }

        // Destroy the bullet after it hits any object
        Destroy(gameObject);
    }
}
