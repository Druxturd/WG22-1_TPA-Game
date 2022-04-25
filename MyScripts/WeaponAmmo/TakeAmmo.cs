using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAmmo : MonoBehaviour
{
    [SerializeField] LayerMask ammoMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(centerScreen);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ammoMask))
        {
            if(hit.collider.gameObject.tag == "PistolAmmo")
            {
                Debug.Log("Pistol Ammo");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
            else if(hit.collider.gameObject.tag == "RifleAmmo")
            {
                Debug.Log("Rifle Ammo");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
