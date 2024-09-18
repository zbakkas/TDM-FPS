using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTps : MonoBehaviour
{
    public Animator an;
    public bool outoShot;
   // public  bool IsCrouching;
    public waopen w;
    public controlPlayer contP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        an.SetFloat("Z", contP._joystick.Vertical);
        an.SetFloat("X", contP._joystick.Horizontal);

        an.SetFloat("Jump",contP.jump);
        an.SetInteger("Weapon", w.namperWeapons);


        ///crouch
        if (contP.bckrouch && contP.IsCrouching ==false)
        {
          
            an.SetBool("IsCrouching", true);
           // contP.IsCrouching = true;

        }
        else if (contP.bckrouch && contP.IsCrouching)
        {
           
            an.SetBool("IsCrouching", false);
            //contP.IsCrouching = false;

        }

        ///JUMP
       /* if (Input.GetKeyDown(KeyCode.Space) )
        {
            an.SetTrigger("IsJump");
        }*/

        //RUN
        if (contP._joystick.Vertical != 0 || contP._joystick.Horizontal != 0)
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                an.SetBool("RUN", true);
            }
            else
            {
                an.SetBool("RUN", false);
            }
        }
        else
        {

            an.SetBool("RUN", false);
        }

        ///SHOOT
       /* if (Input.GetButtonDown("Fire1"))
        {
            an.SetTrigger("Shoot");
        }
       */
        ///RELOAD
        /*
         if (Input.GetKeyDown(KeyCode.R))
        {
            an.SetTrigger("Reload");
           

        }
        */

        ////grenade
/*
        if (Input.GetKeyDown(KeyCode.G))
        {
            an.SetTrigger("IsGrenade");


        }
*/
    }





}
