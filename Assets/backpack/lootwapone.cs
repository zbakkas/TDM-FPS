using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lootwapone : MonoBehaviour
{
    public inventManager inM;
    public ittttem[] itembickup;
    public GameObject[] gun;
    public int nambergunsel;
    /// 
    public polygon_fps_controller pol;
    public waopen wo;


    public bool pistol;
    public Sprite iconpistole;
    public Image buttonpistole;


    ///// grenade 
    public int grenadee;
    public Sprite gr, na;
    public Image im;
    public Text numberGR;
  
    //
    Ray ay;
    RaycastHit hit;
    public Transform P1;
    public Transform P2;
    public float viowrecast;
    //
    public GameObject getloticon, getpistolicon, getgrenadeicon;

    // Start is called before the first frame update
    void Start()
    {
        //
       
        grenadee = 0;
        //
        pistol = false;
        for (int i = 0; i < gun.LongLength; i++)
        {
            gun[i].SetActive(false);
        }
        //
        getloticon.SetActive(false);
        getpistolicon.SetActive(false);
        getgrenadeicon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {/////////////grenade
        if (grenadee != 0)
        {
            im.sprite = gr;
        }
        else
        {
            im.sprite = na;
        }
        numberGR.text = grenadee.ToString();
        //////////////
        if (inM.selectSlot > 0)
        {
            inventorySeyn slot = inM.inventorySeyns[inM.selectSlot];/////////
            inventoruIteeem itmInslot = slot.GetComponentInChildren<inventoruIteeem>();
            
            if ( itmInslot == null)
            {
                inM.changeSelegteSolt(0);
                wo.switchWeapons(0);
            }
        }


        /////////
        ay.origin = P1.position;
        ay.direction = P2.position - P1.position;
        if (Physics.Raycast(ay, out hit, viowrecast))
        {
            

            if (
                hit.collider.gameObject.tag == "grenade"||
                hit.collider.gameObject.tag == "pistol"||
                hit.collider.gameObject.tag == "M16" ||
                hit.collider.gameObject.tag == "akm" ||
                hit.collider.gameObject.tag == "shootgun" ||
                hit.collider.gameObject.tag == "snaiper" ||
                hit.collider.gameObject.tag == "pistolammo" ||
                hit.collider.gameObject.tag == "shotgunammo" ||
                hit.collider.gameObject.tag == "graneammo" ||
                hit.collider.gameObject.tag == "akmammo" ||
                hit.collider.gameObject.tag == "snaiperammo" 
                )
            {
                getloticon.SetActive(true);
            }

            else
            {
                getloticon.SetActive(false);
            }
        }
        else
        {
            getloticon.SetActive(false);
        }


        if (getpistol)
        {
            getpistolicon.SetActive(true);
        }
        if (grenadee > 0)
        {
            getgrenadeicon.SetActive(true);
        }
        else
        {
            getgrenadeicon.SetActive(false);
        }
    }
    public bool getpistol=false;
    /*
    private void OnTriggerEnter(Collider other)
    {
        //////grenade
    
        if (other.gameObject.tag == "grenade")
        {
            Destroy(other.gameObject);
            grenadee = grenadee + 1;
        }
        //pestol

        if (other.gameObject.tag == "pistol")
        {

            Destroy(other.gameObject);
            buttonpistole.sprite = iconpistole;
            getpistol = true;
            
        }

        ///woapen on boxs 
        for (int i = 0; i < inM.inventorySeyns.Length; i++)
        {
            inventorySeyn slot = inM.inventorySeyns[i];/////////
            inventoruIteeem itmInslot = slot.GetComponentInChildren<inventoruIteeem>();
            if (itmInslot == null)
            {
                if (other.gameObject.tag == "M16")
                {
                    Destroy(other.gameObject);

                    //shi.transform.parent = gri.transform;
                    bool result = inM.addItem(itembickup[0]);
                    break;

                }
                else if (other.gameObject.tag == "akm")
                {
                    Destroy(other.gameObject);

                    bool result = inM.addItem(itembickup[1]);
                    break;
                }
                else if (other.gameObject.tag == "shootgun")
                {
                    Destroy(other.gameObject);
                    bool result = inM.addItem(itembickup[2]);
                    break;
                }
                else if (other.gameObject.tag == "snaiper")
                {
                    Destroy(other.gameObject);
                    bool result = inM.addItem(itembickup[3]);
                    break;
                }

            }
        }


        ///////////ammo
        if (other.gameObject.tag == "pistolammo")
        {
            Destroy(other.gameObject);
            ammo a = wo.gun[1].GetComponent<ammo>();
            a.MaxAmoo = a.MaxAmoo + 5;
        }
        if (other.gameObject.tag == "shotgunammo")
        {
            Destroy(other.gameObject);
            ammo a = wo.gun[4].GetComponent<ammo>();
            a.MaxAmoo = a.MaxAmoo + 5;
        }
        if (other.gameObject.tag == "graneammo")
        {
            Destroy(other.gameObject);
            ammo a = wo.gun[2].GetComponent<ammo>();
            a.MaxAmoo = a.MaxAmoo + 40;
        }
        if (other.gameObject.tag == "akmammo")
        {
            Destroy(other.gameObject);
            ammo a = wo.gun[3].GetComponent<ammo>();
            a.MaxAmoo = a.MaxAmoo + 40;
        }
        if (other.gameObject.tag == "snaiperammo")
        {
            Destroy(other.gameObject);
            ammo a = wo.gun[5].GetComponent<ammo>();
            a.MaxAmoo = a.MaxAmoo + 5;
        }
    }
    */
    public void xxxx()
    {
        ammo a = gun[nambergunsel].GetComponent<ammo>();
        a.relodanimatin = false;
        pol.Baimm = false;
    }


    public void pistolesrlcted()
    {
       
        if (!pistol &&getpistol)
        {
            pistol = true;
            inM.changeSelegteSolt(0);
        }
        else
        {
            pistol = false;
            wo.switchWeapons(0);

        }
        lotwoapensslecte();
    }


 


    public void lotwoapensslecte()
    {
        if ( !pistol && inM.boxswoben) 
        {
            ittttem receivedItem = inM.getselecteItem(false);
            for (int i = 0; i < gun.LongLength; i++)
            {
                if (receivedItem == itembickup[i])
                {
                    // gun[i].SetActive(true);

                    nambergunsel = i;
                    wo.switchWeapons(nambergunsel + 2);
                    break;
                }
              
            }
          


        }
        else if (pistol)
        {
            wo.switchWeapons(1);
        }
      
        else
        {
            wo.switchWeapons(0);
        }

    }



    public void getlot()
    {
        ay.origin = P1.position;
        ay.direction = P2.position - P1.position;
        if (Physics.Raycast(ay, out hit, viowrecast))
        {
            Debug.DrawLine(ay.origin, hit.point, Color.red, 1f);
            //////grenade

            if (hit.collider.tag == "grenade")
            {

                Destroy(hit.collider.gameObject);
                grenadee = grenadee + 1;
            }
            //pestol

            if (hit.collider.gameObject.tag == "pistol")
            {

                Destroy(hit.collider.gameObject);
                buttonpistole.sprite = iconpistole;
                getpistol = true;

            }

            ///woapen on boxs 
            for (int i = 0; i < inM.inventorySeyns.Length; i++)
            {
                inventorySeyn slot = inM.inventorySeyns[i];/////////
                inventoruIteeem itmInslot = slot.GetComponentInChildren<inventoruIteeem>();
                if (itmInslot == null)
                {
                    if (hit.collider.gameObject.tag == "M16")
                    {
                        Destroy(hit.collider.gameObject);

                        //shi.transform.parent = gri.transform;
                        bool result = inM.addItem(itembickup[0]);
                        break;

                    }
                    else if (hit.collider.gameObject.tag == "akm")
                    {
                        Destroy(hit.collider.gameObject);

                        bool result = inM.addItem(itembickup[1]);
                        break;
                    }
                    else if (hit.collider.gameObject.tag == "shootgun")
                    {
                        Destroy(hit.collider.gameObject);
                        bool result = inM.addItem(itembickup[2]);
                        break;
                    }
                    else if (hit.collider.gameObject.tag == "snaiper")
                    {
                        Destroy(hit.collider.gameObject);
                        bool result = inM.addItem(itembickup[3]);
                        break;
                    }

                }
            }


            ///////////ammo
            if (hit.collider.gameObject.tag == "pistolammo")
            {
                Destroy(hit.collider.gameObject);
                ammo a = wo.gun[1].GetComponent<ammo>();
                a.MaxAmoo = a.MaxAmoo + 5;
            }
            if (hit.collider.gameObject.tag == "shotgunammo")
            {
                Destroy(hit.collider.gameObject);
                ammo a = wo.gun[4].GetComponent<ammo>();
                a.MaxAmoo = a.MaxAmoo + 5;
            }
            if (hit.collider.gameObject.tag == "graneammo")
            {
                Destroy(hit.collider.gameObject);
                ammo a = wo.gun[2].GetComponent<ammo>();
                a.MaxAmoo = a.MaxAmoo + 40;
            }
            if (hit.collider.gameObject.tag == "akmammo")
            {
                Destroy(hit.collider.gameObject);
                ammo a = wo.gun[3].GetComponent<ammo>();
                a.MaxAmoo = a.MaxAmoo + 40;
            }
            if (hit.collider.gameObject.tag == "snaiperammo")
            {
                Destroy(hit.collider.gameObject);
                ammo a = wo.gun[5].GetComponent<ammo>();
                a.MaxAmoo = a.MaxAmoo + 5;
            }
        }
    }
}
