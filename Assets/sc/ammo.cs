using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ammo : MonoBehaviour
{
    public int Amoo;
    public int MaxAmoo  ;

   public Text Tamo, Tmaxamo;

    public int addAmoo;
    //
    public int Amoo2 = 15;

    public FixedJoystick _joystick;
    public Animator an,an2;

    bool relodd;

   
    public waopen w;
    public bool relodanimatin;

    // Start is called before the first frame update
    void Start()
    {
       relodanimatin = false;
        Amoo = Amoo2;
        relodd = true;
       
    }

    // Update is called once per frame
    void Update()
    {

       


        ///LAG REMOV THIS
        Tamo.text = Amoo.ToString();
       Tmaxamo.text = MaxAmoo.ToString();

        ////////
      
        if ((w.Brelood && Amoo < Amoo2 && MaxAmoo >= 1  ) || (Amoo == 0 && MaxAmoo >0&&!relodanimatin))
        {
           
                //  ani.SetTrigger("relod");
                an.SetTrigger("relode");
                an2.SetTrigger("Reload");
                
             
        }


        


        ///////////////////

        /////////// MOV ANIMATION
        if (_joystick.Vertical != 0 || _joystick.Horizontal != 0)
        {
            an.SetBool("walk", true);
            if (_joystick.Vertical >= 0.99)
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

    public void waitingRelod()
    {
        if (MaxAmoo >= Amoo2)
        {
            MaxAmoo -= Amoo2 - Amoo;
            Amoo += Amoo2 - Amoo;
        }
        if (MaxAmoo < Amoo2 && MaxAmoo - (Amoo2 - Amoo) >= 1)
        {
            MaxAmoo -= Amoo2 - Amoo;
            Amoo += Amoo2 - Amoo;

        }
        if (MaxAmoo - (Amoo2 - Amoo) < 0)
        {
            Amoo += MaxAmoo;
            MaxAmoo -= MaxAmoo;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //z = GameObject.Find("FRDI").GetComponent<WAMOD>();
        //akhd = GameObject.Find("Player").GetComponent<AudioSource>();
        if (other.gameObject.tag == "amoofrdi")
        {
            //akhd.PlayOneShot(clakd);
            //Debug.Log("amozayed");
            //Destroy(gameObject);
            //Destroy(zombie, 4);
            //z.amo = z.amo + amooo;
            MaxAmoo = MaxAmoo + addAmoo;
            
        }
        //

        
    }


    public void norelod()
    {
        relodanimatin = false;
        waitingRelod();
       
    }
    public void yesrelode()
    {
        relodanimatin = true;
    }


 

}
