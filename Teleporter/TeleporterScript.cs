using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterScript : MonoBehaviour
{

    [SerializeField] LayerMask person;
    [SerializeField] GameObject player;

    private bool checkPlayerInRange;
    private int range = 3;

    // Start is called before the first frame update
    void Start()
    {
        range = 3;
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerInRange = Physics.CheckSphere(transform.position, range, person);
        if (checkPlayerInRange)
        {
            //if (QuestScript.isFinish() == true)
            //{
                if (Input.GetKey(KeyCode.F))
                {
                    Data.capPistolAmmo2 = AmmoCount.capPistolAmmo;
                    Data.capRifleAmmo2 = AmmoCount.capRifleAmmo;
                    Data.currPistolAmmo2 = AmmoCount.currPistolAmmo;
                    Data.currRifleAmmo2 = AmmoCount.currRifleAmmo;
                    Debug.Log("Hit");
                    SceneManager.LoadScene("BossScene");
                }

            //}
        }
    }

}
