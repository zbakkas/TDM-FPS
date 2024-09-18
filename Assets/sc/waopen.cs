using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waopen : MonoBehaviour
{
    public GameObject[] gun,gun2;//,cam;
    public int namperWeapons;
    int I;

    public bool Brelood;

    public lootwapone loG;
    // Start is called before the first frame update
    void Start()
    {
        switchWeapons(0);
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        if (Brelood)
        {
            Brelood = false;
        }
    }

    void Update()
    {
       

        ////

        for (int i = 0; i < gun.LongLength; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0+i))
            {
                I = i;
            }
        }

        ///////
        if (Input.GetKeyDown(KeyCode.Alpha0+I))
        {
            if (namperWeapons == I)
            {
                switchWeapons(0);
            }
            else
            {
                switchWeapons(I);
            }
        }

        
    }
    public void switchWeapons(int index)
    {
        for(int i=0;i < gun.LongLength; i++)
        {
            gun[i].SetActive(false);
            gun2[i].SetActive(false);
            // cam[i].SetActive(false);

        }

        gun[index].SetActive(true);
        gun2[index].SetActive(true);
        //  cam[index].SetActive(true);
        namperWeapons = index;
      
    }



    public void Breload()
    {
        Brelood = true;
    }


    public void weapon(int numperWeapon)
    {
        switchWeapons(numperWeapon);
    }



    public void shootgrenade()
    {
        if (loG.grenadee > 0&&namperWeapons>0)
        {
            ammo aa = gun[namperWeapons].GetComponent<ammo>();
            aa.an.SetTrigger("GRENADE");
        }
     
    }

}
