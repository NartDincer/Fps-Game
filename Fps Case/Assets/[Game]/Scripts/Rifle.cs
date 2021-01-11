using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public Transform spawnPoint;
    public float distance = 15f;

    //public AudioSource shootSound;

    public GameObject muzzle;
    public GameObject impact;

    ReloadScript reloadScript;

    void OnEnable()
    {
        WeaponSwitching.SelectedWeapon = gameObject;
    }
    void Start()
    {
        reloadScript = GetComponent<ReloadScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !reloadScript.needReload && !reloadScript.outOfAmmo)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        //shootSound.Play();
        reloadScript.currentAmmo--;

        GameObject muzzleInstance = Instantiate(muzzle, spawnPoint.position, spawnPoint.rotation);
        muzzleInstance.transform.parent = spawnPoint;

        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit, distance))
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
