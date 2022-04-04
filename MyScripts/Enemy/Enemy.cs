using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    public GameObject healthBarUI;
    public Slider slider;

    public Transform targetPlayer;

    public void TakeDmg (float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Start()
    {
        health = maxHealth;
        slider.value = calculateHealth();
    }

    void Update()
    {
        slider.value = calculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        
        if(targetPlayer != null)
        {
            transform.LookAt(targetPlayer);
        }

    }

    float calculateHealth()
    {

        return health / maxHealth;
    }
    void Die()
    {
        Destroy(gameObject);
    }

}
