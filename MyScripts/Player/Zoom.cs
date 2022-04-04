using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Zoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera normalAimCamera;
    [SerializeField] CinemachineVirtualCamera aimCamera;
    private bool getRightMouseInp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getRightMouseInp = Input.GetMouseButton(1);
        if (getRightMouseInp)
        {
            normalAimCamera.gameObject.SetActive(false);
            aimCamera.gameObject.SetActive(true);
        }
        else
        {
            normalAimCamera.gameObject.SetActive(true);
            aimCamera.gameObject.SetActive(false);
        }
    }
}
