using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public int maxHealth = 100;
    public int currHealth;

    public HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TakeDmg(20);
        }
    }

    void TakeDmg(int dmg)
    {
        currHealth -= dmg;

        healthBar.SetHealth(currHealth);
    }

    void Heal()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
}
