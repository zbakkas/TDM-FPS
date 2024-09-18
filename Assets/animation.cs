using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator an;
    public bool outoShot;
    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetButton("Fire2"))
            {
                an.SetBool("Aime", true);
                if (Input.GetButtonDown("Fire1") || (Input.GetButton("Fire1") && outoShot))
                {
                    an.SetTrigger("shot aime");
                    an.SetBool("shot aime outo", true);
                }
                else
                {
                    an.SetBool("shot aime outo", false);
                }
            }
            else
            {
                an.SetBool("Aime", false);
                an.SetBool("shot aime outo", false);
                if (Input.GetButtonDown("Fire1") || (Input.GetButton("Fire1") && outoShot))
                {
                    an.SetBool("shot outo", true);
                    an.SetTrigger("shoot");
                }
                else
                {
                    an.SetBool("shot outo", false);
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                an.SetTrigger("relode");
            }


            if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
            {
                an.SetBool("walk", true);
                if (Input.GetKey(KeyCode.RightShift))
                {
                    an.SetBool("run", true);
                }
                else
                {
                    an.SetBool("run", false);
                }
            }
            else
            {
                an.SetBool("walk", false);
                an.SetBool("run", false);
            }
        }
        
   


   
}
