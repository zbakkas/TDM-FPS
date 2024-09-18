using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demospawn : MonoBehaviour
{
    public inventManager inM;
    public ittttem[] itembickup;

    public void pckupItem(int id)
    {
       bool result = inM.addItem(itembickup[id]);
        if (result == true)
        {
            Debug.Log("ad");
        }
        else
        {
            Debug.Log("no");
        }
    }

    //////////
    public void getSelectedItem()
    {
        ittttem receivedItem = inM.getselecteItem(false);
        if (receivedItem != null)
        {
            Debug.Log("recived"+ receivedItem);
        }
        else
        {
            Debug.Log("no recived");
        }

    }
    public void useSelectedItem()
    {
        ittttem receivedItem = inM.getselecteItem(true);
        if (receivedItem != null)
        {
            Debug.Log("use" + receivedItem);
        }
        else
        {
            Debug.Log("no use");
        }

    }

}
