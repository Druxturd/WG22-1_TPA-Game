using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsunaScript : MonoBehaviour
{

    [SerializeField] GameObject canvasTalk;
    [SerializeField] GameObject asunaTalk;

    public Transform nameCanvas;
    public Transform nameLookAt;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance <= 3 && asunaTalk.activeSelf == false)
        {

        }

        nameCanvas.transform.LookAt(nameLookAt.transform.position + nameLookAt.forward);
    }


}
