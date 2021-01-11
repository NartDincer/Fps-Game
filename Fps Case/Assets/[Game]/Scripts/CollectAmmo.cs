using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectAmmo : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);           

            if (WeaponSwitching.SelectedWeapon.GetComponent<ReloadScript>().canAddMaxAmmo)
            {
                WeaponSwitching.SelectedWeapon.GetComponent<ReloadScript>().AddAmmo();
            }

        }        
    }

   

}
