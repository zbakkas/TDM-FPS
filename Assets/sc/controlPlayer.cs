using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlPlayer : MonoBehaviour
{

    public CharacterController ch;
    public float movespeed;
    float speed;


    public float jump = 0;
    public float isjump;
    public float timjump;



    public Animator an;

    public FixedJoystick _joystick;
    public bool bjump,bckrouch, IsCrouching;
    public Transform headsincrouch;
    public Vector2 PoHeadsInCrouch;

    

    //PhotonView v;

    // Start is called before the first frame update
    void Start()
    {
        speed = movespeed;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }

    private void LateUpdate()
    {
        bckrouch = false;
    }

    // Update is called once per frame
    void Update()
    {

       


        if (_joystick.Vertical>=0.99)
        {
           
            speed = movespeed * 1.7f;
        }
        else
        {
          
            speed = movespeed;
        }

        if (bckrouch && IsCrouching == false)
        {
            ch.center = new Vector3(0, 0.73f, 0);
            ch.height = 1.32f;
            IsCrouching = true;
            headsincrouch.localPosition = new Vector3(headsincrouch.localPosition.x, PoHeadsInCrouch.x, headsincrouch.localPosition.z);

        }
        else if (bckrouch && IsCrouching)
        {
            ch.center = new Vector3(0, 0.91f, 0);
            ch.height = 1.7f;
            IsCrouching = false;
            headsincrouch.localPosition = new Vector3(headsincrouch.localPosition.x, PoHeadsInCrouch.y, headsincrouch.localPosition.z);
        }


    }
    private void FixedUpdate()
    {


     





        ////

        if (bjump && ch.isGrounded)
        {
            jump = isjump;
            an.SetTrigger("IsJump");

        }
        else
        {
            if (ch.isGrounded == false)
            {
                jump -= isjump * timjump * Time.deltaTime;
              
            }

        }
        ///
       //   an.SetFloat("X", Input.GetAxisRaw("Vertical"));
        // an.SetFloat("Y", Input.GetAxisRaw("Horizontal"));

        Vector2 vulompv = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        vulompv.Normalize();

      
        //

      

        Vector3 velocity = (transform.forward * vulompv.y + transform.right * vulompv.x) * speed   + Vector3.up * jump;
        ch.Move(velocity * Time.deltaTime);
 
    }

    public void Bjummp()
    {
        bjump = true;
    }
    public void BNOjummp()
    {
        bjump = false;
    }


    public void Bckraouch()
    {
       bckrouch = true;
    }



 
}
