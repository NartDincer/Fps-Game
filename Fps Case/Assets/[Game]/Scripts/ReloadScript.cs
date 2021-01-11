using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadScript : MonoBehaviour
{
    public int maxAmmo;
    public int defaultAmmo;
    [HideInInspector]
    public int currentAmmo;

    public float reloadSpeed;

    public Text ammoText;
    [HideInInspector]
    public bool needReload;
    public bool outOfAmmo;
    public bool canAddMaxAmmo;

    public Animator reloadAnim;  

    void Start()
    {       
        currentAmmo = defaultAmmo;
    }

    // Update is called once per frame
    void Update()
    {

        if (!outOfAmmo)
        {
            if (Input.GetKeyDown(KeyCode.R) || currentAmmo <= 0)
            {
                needReload = true;
                StartCoroutine(Recharge());
            }
        }        

        if (maxAmmo == 0 && currentAmmo == 0)
        {
            outOfAmmo = true;
        }       
        

        if (maxAmmo >= 90)
        {           
            canAddMaxAmmo = false; // cant add more ammo when it collected.
        }
        else
        {           
            canAddMaxAmmo = true;
        }

        ammoText.text = currentAmmo + "/" + maxAmmo;

        Debug.Log(maxAmmo);
    }
    public void AddAmmo()
    {
        
        if (maxAmmo >= 89)
        {
            maxAmmo = 90;
        }
        else
        {
            maxAmmo += 10;
        }
    }

    private IEnumerator Recharge()
    {
        
        Debug.Log("Reload");
        reloadAnim.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadSpeed);

        var shot = defaultAmmo - currentAmmo;

        if (maxAmmo < shot)
        {
            currentAmmo += maxAmmo;
            maxAmmo = 0;
        }
        else
        {
            currentAmmo += shot;
            maxAmmo -= shot;
        }        
        needReload = false;
        reloadAnim.SetBool("Reloading", false);        
    }
       
        
}