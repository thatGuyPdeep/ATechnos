using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    public bool gameOver;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            gameObject.SetActive(false);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
    }
}
