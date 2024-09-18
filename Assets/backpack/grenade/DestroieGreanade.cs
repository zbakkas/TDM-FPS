using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroieGreanade : MonoBehaviour
{
    public ParticleSystem flash;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bboom());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator bboom()
    {
        yield return new WaitForSeconds(3f);
        flash.Play();
        Destroy(gameObject,1f);
    }
}
