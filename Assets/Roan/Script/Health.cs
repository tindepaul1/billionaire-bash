using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Image healthBar; 
    public float maxHealth = 100f; 
    private float currentHealth; 

    void Start()
    {
        currentHealth = maxHealth; 
        UpdateHealthBar(); 
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; 
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead.");
            GameOver();
            
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth; 
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("RoundOver");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20); 
        }
    }
}
