using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SHOOT : MonoBehaviour
{
    Ray ay;
    RaycastHit hit;

    public Transform P1;
    public Transform P2;

    public float rangshoot;

    public ammo a;
   public Animator an,an2;
    
    public GameObject muzzl;

 

    float timeStamp ;
    public float fireRate ;

    bool run;

    public bool outoShot;
   // public GameObject cam0,cam1,cam2,cam3;

    public GameObject scopSnaiper;
    public Camera cm;
    public Vector3 noZOM, zom;

    public polygon_fps_controller poly;
    public float recoilGUN;
    public Vector2 recoilGUNY;


    public ParticleSystem flash;


    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public GameObject canvDM, Halscouir,closscouir;

    public int Damaggun;
    // Start is called before the first frame update

    void Start()
    {
        P1.localPosition = noZOM; 
       a.relodanimatin = false;
        scopSnaiper.SetActive(false);

        cm.fieldOfView = 60;
        poly.recoil = 0;
        poly.recoilY = 0;

    }



    // Update is called once per frame
    void Update()
    {

      
        if (poly.Bshootouto  && a.Amoo > 0)
        {
            Halscouir.SetActive(true);
            closscouir.SetActive(false);
        }
        else
        {
            Halscouir.SetActive(false);
            closscouir.SetActive(true);
        }



        if (canvDM.activeSelf)
        {
            StartCoroutine(activeDM());
        }


        if (poly.Baimm && !a.relodanimatin)
        {
            if(a.w.namperWeapons == 5 )//SNAIPER
            {
                if (poly.Baimm && !a.relodanimatin)
                {
                    scopSnaiper.SetActive(true);
                    cm.fieldOfView = 10;
                    //cam0.transform.position = cam3.transform.position;
                }

                if (poly.Bshotttt && a.relodanimatin == false && !outoShot )//
                {
                    if (a.Amoo > 0)
                    {
                        an.SetTrigger("shoot");
                        an2.SetTrigger("Shoot");
                        shotting();
                    }
                    scopSnaiper.SetActive(false);
                    cm.fieldOfView =45;
                    P1.localPosition = zom;
                    StartCoroutine(sniaperscoob());
                }
                else
                {
                    
               
                }
            }
            else
            {
                cm.fieldOfView =45;
                P1.localPosition = zom;
              
            }
           

           an.SetBool("Aime", true);
            if (poly.Bshootouto && a.relodanimatin == false && outoShot && a.Amoo > 0)
            {
                flash.Play();
               // amoFX.Emit(1);
                an.SetBool("shot aime outo", true);
                an2.SetTrigger("Shoot");
                timeStamp = timeStamp - Time.deltaTime;
                if (timeStamp <= 0)
                {
                    
                    poly.recoil = recoilGUN;
                    poly.recoilY = Random.Range(recoilGUNY.x, recoilGUNY.y);
                    timeStamp = fireRate;
                    shotting();
                }
            }
            else if (poly.Bshotttt && a.relodanimatin == false && !outoShot)//
            {

                if (a.Amoo > 0)
                {
                    flash.Play();
                  //  amoFX.Emit(1);
                    an.SetTrigger("shot aime");
                    an2.SetTrigger("Shoot");
                    shotting();
                    poly.recoil = recoilGUN;
                    poly.recoilY = Random.Range(recoilGUNY.x, recoilGUNY.y);
                }
            }
            else
            {
                poly.recoil = 0;
                poly.recoilY = 0;
                an.SetBool("shot aime outo", false);
            }

        }
        else
        {

  
            scopSnaiper.SetActive(false);
            cm.fieldOfView = 60;
            P1.localPosition = noZOM;
            an.SetBool("Aime", false);
            an.SetBool("shot aime outo", false);
           

            if (poly.Bshootouto && a.relodanimatin == false && outoShot && a.Amoo > 0)
            {
                flash.Play();
               // amoFX.Emit(1);
                an.SetBool("shot outo", true);
                an2.SetTrigger("Shoot");
                timeStamp = timeStamp - Time.deltaTime;
                if (timeStamp <= 0)
                {
                    
                    poly.recoil = recoilGUN;
                    poly.recoilY = Random.Range(recoilGUNY.x, recoilGUNY.y);
                    timeStamp = fireRate;
                    shotting();
                }
            }
            else if (poly.Bshotttt && a.relodanimatin == false && !outoShot  )//
            {
              
                if (a.Amoo > 0)
                {
                    flash.Play();
               //    amoFX.Emit(1);
                    poly.recoil = recoilGUN;
                    poly.recoilY = Random.Range(recoilGUNY.x, recoilGUNY.y);
                    an.SetTrigger("shoot");
                    an2.SetTrigger("Shoot");
                    shotting();
                }
            }
            else
            {
                an.SetBool("shot outo", false);
                poly.recoil = 0;
                poly.recoilY = 0;
            }
        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            an.SetTrigger("GRENADE");
            an2.SetTrigger("IsGrenade");
        }



            //////
        if (a.relodanimatin)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
            {
             //   ani.SetBool("finixRelode",true);
                a.relodanimatin = false;
            }
        }
        else
        {
            //ani.SetBool("finixRelode", false);
        }


        if ((Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)&& a.w.namperWeapons != 0)
        {
           // ani.SetBool("walk", true);
        }
        else
        {
           // ani.SetBool("walk", false);
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        if (Input.GetButton("Fire2") && a.w.namperWeapons !=0&&!run)
        {
         //   cam0.position = cam2.position;
        }
        else
        {
         //   cam0.position = cam1.position;
        }

    }

    public void shotting()
    {



        //ani.SetTrigger("shot");

        //
        //ADUI.clip = isamoFRDI;
        // ADUI.Play();
        //////
        a.Amoo = a.Amoo - 1;

        //
        // flashFRDI.Emit(1);
        //flash1FRDI.Emit(1);
        ay.origin = P1.position;
        ay.direction = P2.position - P1.position;
        ///
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        //
        if (Physics.Raycast(ay, out hit,rangshoot))
        {
            Debug.DrawLine(ay.origin, hit.point, Color.red, 1f); //khat mkan rasasa
                                                                 //EVCTE MAZZL
           

            targetAnim targetanim = hit.collider.GetComponent<targetAnim>();

            if (targetanim)
            {
                if (targetanim.hilthtarget >0)
                {
                    targetanim.hilthtarget = targetanim.hilthtarget - Damaggun;
                    canvDM.SetActive(true);
                    

                }


            }
            else
            {
                var rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                var effect = Instantiate(muzzl, hit.point, rotation) as GameObject;
                effect.transform.SetParent(vObjectContainer.root, true);
            }

        }
    }

  
    IEnumerator sniaperscoob()
    {
        yield return new WaitForSeconds(1.5f);

        if (Input.GetButton("Fire2") && !a.relodanimatin)
        {
            scopSnaiper.SetActive(true);
            cm.fieldOfView = 20;
        }
           
      
    }
    IEnumerator activeDM()
    {
        yield return new WaitForSeconds(0.08f);
        canvDM.SetActive(false);
      


    }

  

}
     