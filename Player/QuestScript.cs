using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour
{
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] TMP_Text questTxt;
    List<string> questList = new List<string>();
    public bool done;
    public bool onGoing;
    public static bool finish;
    public static int questCtr = 0;
    public int targetHitted = 0;
    public int bulletCtr = 0;
    public static int enemyDied = 0;
    public static int enemyDied2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        InitQuest();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            if (isFkey() && raycastHit.transform.CompareTag("NPC") && questCtr == 0)
            {
                Done();
                done = false;
                onGoing = true;
            }
            else if(isFkey() && raycastHit.transform.CompareTag("NPC") && done == true)
            {
                AmmoCount.addPistolAmmo();
                AmmoCount.addRifleAmmo();
                Done();
                done = false;
                onGoing = true;
            }
            if (isFkey() && raycastHit.transform.CompareTag("Pistol") && questCtr >= 1)
            {
                Destroy(raycastHit.transform.gameObject);

                done = true;
                onGoing = false;
            }
            else if(isFkey() && raycastHit.transform.CompareTag("Rifle") && questCtr >= 3)
            {
                Destroy(raycastHit.transform.gameObject);
            }

            if (Input.GetButtonDown("Fire1") && raycastHit.transform.CompareTag("Target") && AmmoCount.currPistolAmmo > 0)
            {
                Debug.Log("asdasdasd");
                targetHitted += 1;
                if(targetHitted == 10)
                {
                    done = true;
                    onGoing = false;
                }
            }
            if(Input.GetButton("Fire1") && TakeWeapon.isActiveRifle() && AmmoCount.currRifleAmmo > 0)
            {
                bulletCtr += 1;
                if(bulletCtr == 50)
                {
                    done = true;
                    onGoing = false;
                }
            }
        }
        if (questCtr == 5 && done == true)
        {
            finish = true;
        }

        if(enemyDied == 16)
        {
            done = true;
            onGoing = false;
            enemyDied = 0;
        }

        if(enemyDied2 == 8)
        {
            done = false;
            onGoing = false;
            finish = true;
        }

        if (questCtr == 2)
        {
            //done = true;
            //onGoing = false;
            //targetHitted = 10;
            questTxt.text = questList[questCtr] + " (" + targetHitted + " / 10)";
        }
        else if (questCtr == 3)
        {
            //done = true;
            //onGoing = false;
            //bulletCtr = 50;
            questTxt.text = questList[questCtr] + " (" + bulletCtr + " / 50)";
        }
        else if (questCtr == 4)
        {
            //done = true;
            //onGoing = false;
            //enemyDied = 16;
            Destroy(GameObject.Find("FirstDoor"));
            questTxt.text = questList[questCtr] + " (" + enemyDied + " / 16)";
        }
        else if (questCtr == 5)
        {
            //done = true;
            //onGoing = false;
            //enemyDied2 = 8;
            Destroy(GameObject.Find("SecondDoor"));
            //questTxt.text = questList[questCtr] + " (" + enemyDied + " / 8)";
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

    public static bool isFinish()
    {
        return finish;
    }

    public bool isFkey()
    {
        if (Input.GetKey(KeyCode.F))
        {
            return true;
        }
        return false;
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

    public static int GetQCtr()
    {
        return questCtr;
    }
}
