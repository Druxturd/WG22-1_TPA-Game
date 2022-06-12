using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScript : MonoBehaviour
{
    [SerializeField] public CanvasGroup victoryUIGroup;
    [SerializeField] public GameObject victoryUI;
    [SerializeField] public GameObject musicAudio;
    public static bool isVictory;
    QuestScript questScript;

    // Start is called before the first frame update
    void Start()
    {
        victoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            isVictory = true;
        }

        if (isVictory)
        {
            Victory();
            musicAudio.SetActive(false);
        }
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
            if (victoryUIGroup.alpha == 1)
            {
                Time.timeScale = 1f;
                isVictory = false;
            }
        }

    }
}
