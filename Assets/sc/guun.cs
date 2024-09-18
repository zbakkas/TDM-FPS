using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guun : MonoBehaviour
{
    public Animator an;
    public GameObject cam;
    public bool pistol,M16B,shotgunB,snaiperB;
    public GameObject pistolG,camPistol, M16,camM16,shotgun,camshotgun,snaiper,camsnaiper;
    /// 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pistol && !M16B && !shotgunB && !snaiperB)
        {
            cam.SetActive(true);
        }
        else
        {
            cam.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)&&pistol==false)
        {
            M16B = false;
            shotgunB = false;
            snaiperB = false;
            pistol = true;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && pistol == true)
        {
            pistol = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && M16B == false)
        {
            pistol = false;
            shotgunB = false;
            snaiperB = false;
            M16B = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && M16B == true)
        {
            M16B = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && shotgunB == false)
        {
            pistol = false;
            M16B = false;
            snaiperB = false;
            shotgunB = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && shotgunB == true)
        {
            shotgunB = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && snaiperB == false)
        {
            pistol = false;
            M16B = false;
            shotgunB = false;
            snaiperB = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && snaiperB == true)
        {
            snaiperB = false;
        }
        ///////////////////////////////////////



        //////////////////////////////////////////////////////

        if (pistol)
        {
           // pistolG2.SetActive(true);
           // an2.SetBool("pistol", true);
            //////////
            pistolG.SetActive(true);
            camPistol.SetActive(true);
            an.SetBool("pistol", true);

        }
        else
        {
            pistolG.SetActive(false);
            camPistol.SetActive(false);
            an.SetBool("pistol", false);

        }

        if (M16B)
        {
           // shotGun2.SetActive(true);
           // an3.SetBool("shotgun", true);
            //////
            M16.SetActive(true);
            camM16.SetActive(true);
            an.SetBool("M16", true);

        }
        else
        {
          
            M16.SetActive(false);
            camM16.SetActive(false);
            an.SetBool("M16", false);

        }

        if (shotgunB)
        {
            // shotGun2.SetActive(true);
            // an3.SetBool("shotgun", true);
            //////
            shotgun.SetActive(true);
            camshotgun.SetActive(true);
            an.SetBool("shotgun", true);

        }
        else
        {

            shotgun.SetActive(false);
            camshotgun.SetActive(false);
            an.SetBool("shotgun", false);

        }
        if (snaiperB)
        {
            // shotGun2.SetActive(true);
            // an3.SetBool("shotgun", true);
            //////
            snaiper.SetActive(true);
            camsnaiper.SetActive(true);
            an.SetBool("snaiper", true);

        }
        else
        {

            snaiper.SetActive(false);
            camsnaiper.SetActive(false);
            an.SetBool("snaiper", false);

        }

    }
}
