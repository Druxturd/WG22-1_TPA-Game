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
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("Hit");
                SceneManager.LoadScene("BossScene");
            }
        }
    }
}
