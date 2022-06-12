using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudio : MonoBehaviour
{
    private bool checkPlayerInRange;
    private int range = 3;
    [SerializeField] LayerMask person;
    [SerializeField] GameObject player;
    public GameObject MusicAudio;
    public GameObject BattleAudio;
    public GameObject HealthBarBoss;

    // Start is called before the first frame update
    void Start()
    {
        MusicAudio.SetActive(true);
        BattleAudio.SetActive(false);
        HealthBarBoss.SetActive(false);
        range = 2;
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerInRange = Physics.CheckSphere(transform.position, range, person);
        if (checkPlayerInRange)
        {
            MusicAudio.SetActive(false);
            BattleAudio.SetActive(true);
            HealthBarBoss.SetActive(true);
        }
    }
}
