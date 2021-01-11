using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    
    public Transform spawnPoint;
    public float distance = 15f;
    private bool isFiring;

    Camera camera;

    public GameObject muzzle;
    public GameObject impact;

    float shotCounter;
    float rateofFire = 0.1f;

    
    ReloadScript reloadScript;

    void OnEnable()
    {
        WeaponSwitching.SelectedWeapon = gameObject;
    }
    void Start()
    {
        reloadScript = GetComponent<ReloadScript>();       
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isFiring = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            isFiring = false;
        }

        if (isFiring && !reloadScript.needReload && !reloadScript.outOfAmmo)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = rateofFire;
            }
            else
            {
                shotCounter -= Time.deltaTime;
            }
            MGShoot();
        }
    }

    private void MGShoot()
    {
        RaycastHit hit;
        
        reloadScript.currentAmmo--;        

        GameObject muzzleInstance = Instantiate(muzzle, spawnPoint.position, spawnPoint.rotation);
        muzzleInstance.transform.parent = spawnPoint;

        if (Physics.Raycast(camera.transform.position,camera.transform.forward, out hit, distance))
        {
            Debug.Log("hit");
            
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            if (hit.transform.tag == "damagable")
            {
                Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            Debug.Log("not hit");
        }
    }
}
