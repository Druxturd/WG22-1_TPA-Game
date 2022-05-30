using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadScript : MonoBehaviour
{
    [SerializeField] public CanvasGroup deathUIGroup;
    [SerializeField] public GameObject deathUI;
    [SerializeField] public GameObject musicAudio;
    public static bool isDead;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        deathUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value == 0)
        {
            isDead = true;
        }
        if (isDead)
        {
            Dead();
            musicAudio.SetActive(false);
        }
    }

    void Dead()
    {
        Time.timeScale = 0f;
        if (deathUIGroup.alpha <= 1)
        {
            //deathUIGroup.alpha += Time.deltaTime;
            deathUIGroup.alpha += 0.005f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            deathUI.SetActive(true);
            if (deathUIGroup.alpha == 1)
            {
                isDead = false;
            }
        }
    }
}
