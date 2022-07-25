
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections; 
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;

/// Thanks for downloading my projectile gun script! :D
/// Feel free to use it in any project you like!
/// 
/// The code is fully commented but if you still have any questions
/// don't hesitate to write a yt comment
/// or use the #coding-problems channel of my discord server
/// 
/// Dave
public class Guns4Hire : MonoBehaviour
{

    [SerializeField] private InputActionReference ShootEm;

    //bullet 
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    //buzzBoi
    public XRBaseController BuzzController; 
    public float gunBuzzAmp = 0.5f;  
    public float gunBuzzDuration = 0.2f; 


    int bulletsLeft, bulletsShot;

    //Recoil
    public Rigidbody playerRb;
    public float recoilForce;

    //bools
    bool shooting;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public Transform aimPoint;
    public AudioSource source; 
    public AudioClip clip; 

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //bug fixing :D
    public bool allowInvoke = true;

    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazineSize;
        //readyToShoot = true;
    }

    private void Update()
    {
            ShootEm.action.performed += Shoot;

        //Set ammo display, if it exists :D
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }


    private void Shoot(InputAction.CallbackContext obj)
    {
        //readyToShoot = false;

        //Find the exact hit position using a raycast

        BuzzController.SendHapticImpulse(gunBuzzAmp,gunBuzzDuration); 


        RaycastHit hit;
        Physics.Raycast(attackPoint.position, attackPoint.forward, out hit); 
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(attackPoint.position, attackPoint.forward, out hit)){
            
        }

        if (Physics.Raycast(ray))
            targetPoint = hit.point; //you could try putting the else thing here, so its just always a point 75 meters away. idk
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the player
        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = aimPoint.position - attackPoint.position;

        float x = 0; 
        float y = 0; 


        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        source.PlayOneShot(clip);
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);
        //currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        //Instantiate muzzle flash, if you have one
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            //Add recoil to player (should only be called once)
            playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }

        //if more than one bulletsPerTap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        //Allow shooting and invoking again
        //readyToShoot = true;
        allowInvoke = true;
    }

    // private void Reload()
    // {
    //     reloading = true;
    //     Invoke("ReloadFinished", reloadTime); //Invoke ReloadFinished function with your reloadTime as delay
    // }
    // private void ReloadFinished()
    // {
    //     //Fill magazine
    //     bulletsLeft = magazineSize;
    //     reloading = false;
    // }
}
