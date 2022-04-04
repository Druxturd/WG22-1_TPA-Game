using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Crosshair : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera AimCamera;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // aim crosshair
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            if (raycastHit.transform.CompareTag("Pistol"))
            {
                //Debug.Log("Pistol");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    print("Take Pistol");
                }
            }
            else if (raycastHit.transform.CompareTag("Rifle"))
            {
                //Debug.Log("Rifle");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    print("Take Rifle");
                }
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(AimCamera.transform.position, AimCamera.transform.forward, out hit, 999f))
        {
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            if(target != null)
            {
                target.TakeDmg(10);
            }
        }
    }
}
