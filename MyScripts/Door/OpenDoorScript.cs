using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    private bool checkPlayerInRange;
    private int range = 3;
    [SerializeField] LayerMask person;
    [SerializeField] GameObject player;

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
            Destroy(gameObject);
        }
    }
}
