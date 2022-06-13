using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Crosshair : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera AimCamera;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private GameObject pistolTxt;
    [SerializeField] private GameObject rifleTxt;
    [SerializeField] private GameObject interactTxt;
    public AudioSource source;
    public AudioClip rifleClip;
    public AudioClip pistolClip;
    //[SerializeField] TeleporterScript teleporterScript;

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
                pistolTxt.SetActive(true);
                //rifleTxt.SetActive(false);
                //Debug.Log("Pistol");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    print("Take Pistol");
                }
            }
            else if (raycastHit.transform.CompareTag("Rifle"))
            {
                //pistolTxt.SetActive(false);
                rifleTxt.SetActive(true);
                //Debug.Log("Rifle");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    print("Take Rifle");
                }
            }
            else if (raycastHit.transform.CompareTag("NPC"))
            {

                interactTxt.SetActive(true);

            }
            else if (raycastHit.transform.CompareTag("Teleporter"))
            {
            }
            else
            {
                pistolTxt.SetActive(false);
                rifleTxt.SetActive(false);
                interactTxt.SetActive(false);
            }
        }

        if (TakeWeapon.isActivePistol() && AmmoCount.currPistolAmmo > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootPistol();
                source.PlayOneShot(pistolClip, 0.5f);
            }
        }
        else if (TakeWeapon.isActiveRifle() && AmmoCount.currRifleAmmo > 0)
        {
            if (Input.GetButton("Fire1"))
            {
                ShootRifle();
                source.PlayOneShot(rifleClip, 0.5f);
            }
        }

    }

    void ShootPistol()
    {
        RaycastHit hit;
        if(Physics.Raycast(AimCamera.transform.position, AimCamera.transform.forward, out hit, 999f))
        {
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            Boss bossTarget = hit.transform.GetComponent<Boss>();
            //if(target != null)
            //{
            //    target.TakeDmg(10);
            //}

            if (hit.transform.CompareTag("Enemy") || hit.transform.CompareTag("Enemy2")){
                if (TakeWeapon.isActivePistol() && AmmoCount.currPistolAmmo > 0)
                {
                    target.TakeDmg(70);
                }
            }
            else if (hit.transform.CompareTag("Boss"))
            {
                if (TakeWeapon.isActivePistol() && AmmoCount.currPistolAmmo > 0)
                {
                    bossTarget.bossHealth -= 70;
                    bossTarget.TakeDamage(70);
                }
            }
          
        }
    }
    void ShootRifle()
    {
        RaycastHit hit;
        if (Physics.Raycast(AimCamera.transform.position, AimCamera.transform.forward, out hit, 999f))
        {
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            Boss bossTarget = hit.transform.GetComponent<Boss>();
            //if(target != null)
            //{
            //    target.TakeDmg(10);
            //}

            if (hit.transform.CompareTag("Enemy") || hit.transform.CompareTag("Enemy2"))
            {
                if (TakeWeapon.isActiveRifle() && AmmoCount.currRifleAmmo > 0)
                {
                    target.TakeDmg(35);
                }
            }
            else if (hit.transform.CompareTag("Boss"))
            {
                if (TakeWeapon.isActiveRifle() && AmmoCount.currRifleAmmo > 0)
                {
                    bossTarget.bossHealth -= 35;
                    bossTarget.TakeDamage(35);
                }
            }

        }
    }
}
