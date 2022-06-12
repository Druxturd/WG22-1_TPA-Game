using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoCount : MonoBehaviour
{

    [SerializeField] TMP_Text ammo;

    public static int capPistolAmmo;
    public static int currPistolAmmo;
    public static int capRifleAmmo;
    public static int currRifleAmmo;

    public RawImage rifleImg;
    public RawImage pistolImg;
    public Color activeColor;
    public Color offColor;

    // Start is called before the first frame update
    void Start()
    {
        activeColor.a = 1;
        offColor.a = 1;
        currPistolAmmo = 7;
        capPistolAmmo = 14;
        currRifleAmmo = 30;
        capRifleAmmo = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (TakeWeapon.isActiveRifle() && TakeWeapon.isTakeRifle())
        {
            TakeWeapon.isPistol = false;
            TakeWeapon.isRifle = true;
            pistolImg.color = offColor;
            rifleImg.color = activeColor;
            ammo.text = (currRifleAmmo) + " / " + capRifleAmmo;
            if(Input.GetButton("Fire1") && currRifleAmmo > 0)
            {
                currRifleAmmo -= 1;
            }
            if(Input.GetKey(KeyCode.R) && currRifleAmmo < 30 && capRifleAmmo > 0)
            {
                if((currRifleAmmo + capRifleAmmo) >= 30)
                {
                    capRifleAmmo = (currRifleAmmo + capRifleAmmo) - 30;
                    currRifleAmmo = 30;
                }
                else
                {
                    currRifleAmmo = currRifleAmmo + capRifleAmmo;
                    capRifleAmmo = 0;
                }
            }
        }
        if (TakeWeapon.isActivePistol() && TakeWeapon.isTakePistol())
        {
            TakeWeapon.isPistol = true;
            TakeWeapon.isRifle = false;
            pistolImg.color = activeColor;
            rifleImg.color = offColor;
            ammo.text = (currPistolAmmo) + " / " + capPistolAmmo;
            if(Input.GetButtonDown("Fire1") && currPistolAmmo > 0)
            {
                currPistolAmmo -= 1;
            }
            if (Input.GetKey(KeyCode.R) && currPistolAmmo < 7 && capPistolAmmo > 0)
            {
                if ((currPistolAmmo + capPistolAmmo) >= 7)
                {
                    capPistolAmmo = (currPistolAmmo + capPistolAmmo) - 7;
                    currPistolAmmo = 7;
                }
                else
                {
                    currPistolAmmo = currPistolAmmo + capPistolAmmo;
                    capPistolAmmo = 0;
                }
            }
        }
        if (ActiveWeapon.PressThree())
        {
            if (QuestScript.GetQCtr() >= 3)
            {
                TakeWeapon.isPistol = false;
                pistolImg.color = offColor;
                TakeWeapon.isRifle = false;
                rifleImg.color = offColor;
            }
            else if (QuestScript.GetQCtr() >= 1)
            {
                TakeWeapon.isPistol = false;
                pistolImg.color = offColor;
            }
            ammo.text = "";
        }
    }

    public static void addPistolAmmo()
    {
        capPistolAmmo += 7;
    }

    public static void addRifleAmmo()
    {
        capRifleAmmo += 30;
    }
}
