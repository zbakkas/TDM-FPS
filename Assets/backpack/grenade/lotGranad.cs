using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lotGranad : MonoBehaviour
{
    public int grenadee;

    public Sprite gr, na;
    public Image im;
    public Text numberGR;



    public GameObject cader;
    public bool selecter;
    private void Start()
    {
        selecter = false;
        cader.SetActive(false);
        grenadee = 0;
    }
    private void Update()
    {
        if (grenadee != 0)
        {
            im.sprite = gr;
        }
        else
        {
            im.sprite = na;
        }
        numberGR.text = grenadee.ToString();
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "grenade")
        {
            Destroy(other.gameObject);
            grenadee = grenadee + 1;
        }
        //

    }

    public void selectee()
    {
        if (selecter == false)
        {
            selecter = true;
            cader.SetActive(true);
        }
        else
        {
            cader.SetActive(false);
            selecter = false;
        }
        
    }

}
