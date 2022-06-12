using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int enemyHealth = 100;
    // Start is called before the first frame update

    private Transform _transform;

    [SerializeField] GameObject player;


    private int fireRate = 10;
    private int damage = 1;

    public Transform HealthBarCanvas;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public bool checkAmmoDropped;

    [SerializeField] private GameObject pistolAmmo;
    [SerializeField] private GameObject rifleAmmo;

    void Start()
    {
        fireRate = 10;
        damage = 1;
        enemyHealth = 100;
        checkAmmoDropped = false;
        _transform = GetComponent<Transform>();
        SetSliderMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //slider.value = enemyHealth;
        //fill.color = gradient.Evaluate(slider.normalizedValue);
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (enemyHealth <= 0)
        {
            int ammoDropChance = Random.Range(0, 2);
            int ammoTypeChance = Random.Range(0, 2);
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            transform.position += (Vector3.down * Time.deltaTime) * 2;
            if (ammoDropChance == 1 && checkAmmoDropped == false)
            {
                Vector3 position = transform.position;
                position.y = Terrain.activeTerrain.SampleHeight(transform.position) + 0.1f;
                if (ammoTypeChance == 0)
                {
                    Instantiate(rifleAmmo, position, Quaternion.identity);
                }
                else if (ammoTypeChance == 1)
                {

                    Instantiate(pistolAmmo, position, Quaternion.Euler(new Vector3(0, 0, -180)));
                }
                checkAmmoDropped = true;
                Debug.Log("drop");
            }
            if (_transform.position.y <= -3)
            {
                Destroy(this.gameObject);
            }
            if (this.gameObject.CompareTag("Enemy"))
            {
                transform.gameObject.tag = "DeadEnemy";
                QuestScript.enemyDied += 1;
            }

        }
        else if (distance <= 25f)
        {
            lookPlayer();
        }

        HealthBarCanvas.transform.LookAt(player.transform.position);
    }

    public void TakeDmg(int damage)
    {
        enemyHealth -= damage;
        slider.value = enemyHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetSliderMaxHealth()
    {
        slider.maxValue = enemyHealth;
        slider.value = enemyHealth;

        fill.color = gradient.Evaluate(1f);
    }

    public void lookPlayer()
    {
        transform.LookAt(player.transform);
    }



    //public float health = 100f;
    //public float maxHealth = 100f;

    //public GameObject healthBarUI;
    //public Slider slider;

    //public Transform targetPlayer;

    //public void TakeDmg(float amount)
    //{
    //    health -= amount;
    //    if (health <= 0f)
    //    {
    //        Die();
    //    }
    //}

    //void Start()
    //{
    //    health = maxHealth;
    //    slider.value = calculateHealth();
    //}

    //void Update()
    //{
    //    slider.value = calculateHealth();

    //    if (health < maxHealth)
    //    {
    //        healthBarUI.SetActive(true);
    //    }

    //    if (health <= 0)
    //    {
    //        Destroy(gameObject);
    //    }

    //    if (health > maxHealth)
    //    {
    //        health = maxHealth;
    //    }

    //    if (targetPlayer != null)
    //    {
    //        transform.LookAt(targetPlayer);
    //    }

    //}

    //float calculateHealth()
    //{

    //    return health / maxHealth;
    //}
    //void Die()
    //{
    //    Destroy(gameObject);
    //}

}
