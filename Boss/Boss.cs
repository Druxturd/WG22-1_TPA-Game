using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public int bossHealth = 2000;
    //public int currHealth;

    [SerializeField] public CanvasGroup victoryUIGroup;
    [SerializeField] public GameObject victoryUI;
    public static bool isVictory;
    public GameObject BattleAudio;

    public HealthBarScript healthBar;
    public Slider slider;

    private int fireRate;
    private int damage;


    // Start is called before the first frame update
    void Start()
    {
        //currHealth = maxHealth;
        bossHealth = 2000;
        healthBar.SetMaxHealth(bossHealth);
        fireRate = 14;
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            TakeDamage(20);
        }
        if (slider.value <= 0)
        {
            isVictory = true;
        }
        if (isVictory)
        {
            BattleAudio.SetActive(false);
            Victory();
        }
    }

    public void TakeDamage(int dmg)
    {
        //bossHealth -= dmg;

        healthBar.SetHealth(bossHealth);
    }

    void Victory()
    {
        Time.timeScale = 0f;
        if (victoryUIGroup.alpha <= 1)
        {
            //victoryUIGroup.alpha += Time.deltaTime;
            victoryUIGroup.alpha += 0.05f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            victoryUI.SetActive(true);
            if(victoryUIGroup.alpha == 1)
            {
                Time.timeScale = 1f;
                isVictory = false;
            }
        }

    }
}
