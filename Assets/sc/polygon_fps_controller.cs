using UnityEngine;
using UnityEngine.UI;

public class polygon_fps_controller : MonoBehaviour
{

    private void Start()
    {
        slid.value = 5;
    }
    /// ////////////////////////////////////////////////////////////////////////
    /// 
    private void Update()
    {
        VS = slid.value;
        HS = slid.value;
        textsistty.text = slid.value.ToString();
        
    }
    private void LateUpdate()
    {
        
        aimming();
        if (Bshotttt)
        {
            Bshotttt = false;
        }
    }
    public Slider slid;
    public Text textsistty;


    public GameObject DHAR,hands;

    public float min_angle;
    public float max_angle;

    public float VS;
    public float HS;

    public float saved_roation_X;
    public float recoil, recoilY;
    public aimeScereen xx;
    public GameObject bu, im;
    public bool Baimm, Bshotttt, Bshootouto;
    public void aimming()
    {

        // float Xm = Input.GetAxis("Mouse X");
        // float Ym = Input.GetAxis("Mouse Y");

        float Xm =xx.TouchDist.x;
         float Ym = xx.TouchDist.y;


        // adding recoil movement to the aim

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, (transform.eulerAngles.y ) + Xm * Time.deltaTime * HS, transform.eulerAngles.z);



        ///////// >>>Z
        /*
        Vector3 rot = new Vector3(DHAR.transform.eulerAngles.x*0, DHAR.transform.eulerAngles.y, (saved_roation_X) - Ym * Time.deltaTime * VS);

        // limit of rotation for the aimming
        rot.z = Mathf.Clamp(rot.z, min_angle, max_angle);


        // Here gets the current roation value saved to reuse it, that we don't begin at zero, because the animation overplays all
        saved_roation_X = rot.z;



        DHAR.transform.eulerAngles = rot;
        */
        ///////////////////////////////////

        //////  >>>X

        Vector3 rot = new Vector3((saved_roation_X) - Ym * Time.deltaTime * VS,DHAR.transform.eulerAngles.y, DHAR.transform.eulerAngles.z * 0); ;

        // limit of rotation for the aimming
        rot.x = Mathf.Clamp(rot.x, min_angle, max_angle);


        // Here gets the current roation value saved to reuse it, that we don't begin at zero, because the animation overplays all
        saved_roation_X = rot.x;

        //////////
        ///Hands

        DHAR.transform.eulerAngles = rot;


        Vector3 rot2 = new Vector3((saved_roation_X) - Ym * Time.deltaTime * VS + recoil, hands.transform.eulerAngles.y+recoilY, hands.transform.eulerAngles.z * 0); ;

        // limit of rotation for the aimming
        rot2.x = Mathf.Clamp(rot2.x, min_angle, max_angle);


        // Here gets the current roation value saved to reuse it, that we don't begin at zero, because the animation overplays all
        saved_roation_X = rot2.x;


        hands.transform.eulerAngles = rot2;
        /////

    }

    public void Bimmme()
    {
        if (!Baimm)
        {
            Baimm = true;
        }
        else
        {
            Baimm = false;
        }

    }


    public void BshootS()
    {
        Bshotttt = true;
        
    }
    public void BshootO()
    {
        Bshootouto = true;

    }

    public void BNOshoot()
    {
      
        Bshootouto = false;
    }


    public void touchScreenSelcted()
    {
        xx = bu.GetComponent<aimeScereen>();
    }
    public void touchScreenSelctedNON()
    {
        xx = im.GetComponent<aimeScereen>();
    }
}
