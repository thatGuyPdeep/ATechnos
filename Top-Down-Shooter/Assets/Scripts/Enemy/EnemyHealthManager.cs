using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    public int currentHealth;

    public EnemyHealthBar enimiesHealthBar;

    void Start()
    {
        currentHealth = health;
        enimiesHealthBar.SetMaxHealth(health);
    }


    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            ScoreScript.scoreValue++;
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
        enimiesHealthBar.SetHealth(currentHealth);
    }
}
