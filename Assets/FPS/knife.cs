using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public Animation an;
    public FixedJoystick _joystick;
    bool SHOOT, SHOOTgrenade;
    bool attak1 = false;
    public waopen w;
    // Start is called before the first frame update
    void Start()
    {
        an.clip = an.GetClip("take_out_knife");
        an.Play();
        SHOOT = false;
        SHOOTgrenade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (w.namperWeapons==0)
        {
            if (_joystick.Vertical > 0 || _joystick.Horizontal > 0)
            {

                an.clip = an.GetClip("walk_knife_d2");
                an.Play();
            }
            else if (_joystick.Vertical == 0 && _joystick.Horizontal == 0 && !SHOOT && !SHOOTgrenade)
            {
                an.clip = an.GetClip("idle_knife_d1");
                an.Play();
            }
        }
       
      
    }

    public void shootK()
    {
        if (w.namperWeapons == 0)
        {
            if (attak1)
            {
                an.clip = an.GetClip("attack_knife_d1");
                attak1 = false;
            }
            else
            {
                an.clip = an.GetClip("attack2_knife");
                attak1 = true;
            }
            an.Play();
            SHOOT = true;
            StartCoroutine(shono());
        }
            
    }
    public void shootG()
    {
        if (w.namperWeapons == 0)
        {
            an.clip = an.GetClip("grenade_knife_d2");
            an.Play();
            SHOOTgrenade = true;
            StartCoroutine(Shotgrenade());
        }
            
    }


    IEnumerator shono()
    {
        yield return new WaitForSeconds(0.4f);
        SHOOT = false;
    }
    IEnumerator Shotgrenade()
    {
        yield return new WaitForSeconds(0.6f);
        SHOOTgrenade = false;
    }
}
