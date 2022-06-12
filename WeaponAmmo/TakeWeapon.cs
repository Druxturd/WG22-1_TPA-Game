using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeWeapon : MonoBehaviour
{
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    public RawImage rifleImg;
    public RawImage pistolImg;
    public Color activeColor;
    public Color offColor;
    public static bool isRifle;
    public static bool isPistol;
    public static bool takeRifle;
    public static bool takePistol;

   
    void Start()
    {
        activeColor.a = 1;
        offColor.a = 1;
        isRifle = false;
        isPistol = false;
        takeRifle = false;
        takePistol = false;
    }

    void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (isFkey() && Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            if(isFkey() && QuestScript.GetQCtr() == 1 && raycastHit.transform.CompareTag("Pistol"))
            {
                pistolImg.color = activeColor;
                isPistol = true;
                takePistol = true;
            }
            if(isFkey() && QuestScript.GetQCtr() == 3 && raycastHit.transform.CompareTag("Rifle"))
            {
                if (isPistol)
                {
                    pistolImg.color = offColor;
                    isPistol = false;
                }
                rifleImg.color = activeColor;
                isRifle = true;
                takeRifle = true;
            }
        }
        
    }

    public bool isFkey()
    {
        if (Input.GetKey(KeyCode.F))
        {
            return true;
        }
        return false;
    }

    public static bool isActiveRifle()
    {
        return isRifle;
    }
    
    public static bool isActivePistol()
    {
        return isPistol;
    }

    public static bool isTakeRifle()
    {
        return takeRifle;
    }

    public static bool isTakePistol()
    {
        return takePistol;
    }
}
