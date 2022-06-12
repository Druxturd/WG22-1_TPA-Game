using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveWeapon : MonoBehaviour
{
    public RawImage rifleImg;
    public RawImage pistolImg;
    public Color activeColor;
    public Color offColor;

    // Start is called before the first frame update
    void Start()
    {
        activeColor.a = 1;
        offColor.a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PressOne() && QuestScript.GetQCtr() >= 3 && TakeWeapon.isActiveRifle() == false && TakeWeapon.isTakeRifle())
        {
            TakeWeapon.isPistol = false;
            TakeWeapon.isRifle = true;
            pistolImg.color = offColor;
            rifleImg.color = activeColor;
        }
        if(PressTwo() && QuestScript.GetQCtr() >= 1 && TakeWeapon.isActivePistol() == false && TakeWeapon.isTakePistol())
        {
            TakeWeapon.isPistol = true;
            TakeWeapon.isRifle = false;
            pistolImg.color = activeColor;
            rifleImg.color = offColor;
        }
        if (PressThree())
        {
            if(QuestScript.GetQCtr() >= 3)
            {
                TakeWeapon.isPistol = false;
                pistolImg.color = offColor;
                TakeWeapon.isRifle = false;
                rifleImg.color = offColor;
            }
            else if(QuestScript.GetQCtr() >= 1)
            {
                TakeWeapon.isPistol = false;
                pistolImg.color = offColor;
            }
        }
    }

    public static bool PressOne()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            return true;
        }
        return false;
    }

    public static bool PressTwo()
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            return true;
        }
        return false;
    }

    public static bool PressThree()
    {
        if (Input.GetKey(KeyCode.Alpha3))
        {
            return true;
        }
        return false;
    }

}
