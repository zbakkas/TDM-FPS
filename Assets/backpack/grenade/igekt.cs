using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class igekt : MonoBehaviour
{
    public GameObject grenade;
    public int force = 800;
    public lootwapone loG;
    public polygon_fps_controller poly;
    public Transform p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void inamationshotgrenade()
    {
        if (loG.grenadee > 0)
        {
            GameObject go = Instantiate(grenade, p.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * force);
            loG.grenadee = loG.grenadee - 1;
        }
    }
}
