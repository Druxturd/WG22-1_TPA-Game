using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestScript : MonoBehaviour
{

    [SerializeField] TMP_Text questTxt;
    List<string> questList = new List<string>();
    public bool done;
    public bool onGoing;
    public bool finish;
    public int questCtr = 0;
    public int targetHitted = 0;
    public int bulletCtr = 0;
    public int enemyDied = 0;
    public int enemyDied2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        InitQuest();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Done();
            if(questCtr == 5)
            {
                finish = true;
            }
        }

        if(questCtr == 2)
        {
            done = true;
            onGoing = false;
            targetHitted = 10;
            questTxt.text = questList[questCtr] + " (" + targetHitted + " / 10";
        }
        else if(questCtr == 3)
        {
            done = true;
            onGoing = false;
            bulletCtr = 50;
            questTxt.text = questList[questCtr] + " (" + bulletCtr + " / 50";
        }
        else if (questCtr == 4)
        {
            done = true;
            onGoing = false;
            enemyDied = 16;
            questTxt.text = questList[questCtr] + " (" + enemyDied + " / 16";
        }
        else if (questCtr == 5)
        {
            done = true;
            onGoing = false;
            enemyDied2 = 8;
            questTxt.text = questList[questCtr] + " (" + enemyDied + " / 8";
        }
        else
        {
            questTxt.text = questList[questCtr];
        }
        if (done)
        {
            questTxt.color = Color.green;
            questTxt.text = questList[questCtr] + "(done)";
        }
        else if (!done)
        {
            questTxt.color = Color.yellow;
        }
    }

    public void Done()
    {
        questCtr += 1;
        done = true;
    }

    void InitQuest()
    {
        questList.Add("Talk to Asuna");
        questList.Add("Pick up the pistol");
        questList.Add("Shoot 10 rounds to the target!");
        questList.Add("Shoot 50 bullets with the Rifle");
        questList.Add("Eliminate the soldiers that are attacking the village");
        questList.Add("Head to the secret teleport room and defeat the boss!");
    }

    public bool GetQuestStats()
    {
        return finish;
    }
}
