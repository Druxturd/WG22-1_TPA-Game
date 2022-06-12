using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{

    public static int capPistolAmmo2;
    public static int currPistolAmmo2;
    public static int capRifleAmmo2;
    public static int currRifleAmmo2;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "BossScene")
        {
            QuestScript.questCtr = 5;
            TakeWeapon.takePistol = true;
            TakeWeapon.takeRifle = true;
            AmmoCount.capPistolAmmo = capPistolAmmo2;
            AmmoCount.capRifleAmmo = capRifleAmmo2;
            AmmoCount.currPistolAmmo = currPistolAmmo2;
            AmmoCount.currRifleAmmo  = currRifleAmmo2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "BossScene")
        {
            Debug.Log("boss");
        }
    }
}
